using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace BSMatchMaker {
	public partial class ResultSelector : UserControl {
		private const int X_MARGIN = 3;
		private const int Y_MARGIN = 3;
		private const int CONTROL_WIDTH = 33;
		private const int CONTROL_HEIGHT = 22;

		public event Action OnUpdate;

		private class InternalRadioButton: RadioButton{
			private int player1_point;
			private int player2_point;

			public InternalRadioButton(Point pt, Match match, int player1_point, int player2_point){
				this.player1_point = player1_point;
				this.player2_point = player2_point;
				Click += (o, e) => { match.Update(player1_point, player2_point); };
				Text = player1_point + "-" + player2_point;
				Appearance = System.Windows.Forms.Appearance.Button;
				AutoSize = true;
				Location = pt;
				TabStop = true;
			}

			public bool IsTarget(Match match) {
				return match.IsTarget(player1_point,player2_point);
			}
		}

		private static int[][]table_3point = new int[][]{
							new int[]{2,0},
							new int[]{2,1},
							new int[]{1,0},
							new int[]{1,1},
							new int[]{0,0},
							new int[]{0,1},
							new int[]{1,2},
							new int[]{0,2}};
		private static int[][] table_1point = new int[][]{
							new int[]{1,0},
							new int[]{0,0},
							new int[]{0,1}};

		public ResultSelector(bool is_three_point_match, Match match)
			:this(is_three_point_match?table_3point:table_1point,match){
		}
		private ResultSelector(int[][] table, Match match) {
			var pt = new Point(X_MARGIN, Y_MARGIN);
			foreach(var p in table){
				var item = new InternalRadioButton(pt, match, p[0], p[1]);
				item.Click += (o, e) => { OnUpdate(); };
				Controls.Add(item);
				pt.Offset(CONTROL_WIDTH + X_MARGIN, 0);
			}
			Init(match);
			pt.Offset(0,CONTROL_HEIGHT+Y_MARGIN);
			Size = new Size(pt);
			Enabled = (!match.IsBYEGame) && match.Status != Match.STATUS.MATCHING;
		}

		private void Init(Match match) {
			if (match.Status == Match.STATUS.DONE) {
				GetTargetRadioButton(match).Checked = true;
			}
		}

		private RadioButton GetTargetRadioButton(Match match) {
			foreach (InternalRadioButton c in Controls) {
				if (c.IsTarget(match)) {
					return c;
				}
			}
			return null;
		}
	}
}
