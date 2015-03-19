using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace BSMatchMaker {
    public partial class FormMatchList : Form {
        private GameNavigator navigator;
		public event Action OnPointChanged;

        internal FormMatchList(Game game) {
			navigator = new GameNavigator(game);
            InitializeComponent();

			DoUpdate();
            navigator.OnUpdate += DoUpdate;
        }

        private void DoUpdate() {
			var round = navigator.Current;
            Text = round.Title;
            switch (round.Status) {
				case Match.STATUS.UNDEF:
					buttonStart.Enabled = false;
					buttonPrev.Enabled = false;
					buttonNext.Text = "Make";
					buttonNext.Enabled = true;
					break;
				case Match.STATUS.MATCHING:
                    buttonStart.Enabled = true;
                    buttonPrev.Enabled = navigator.HasPrev;
                    buttonNext.Text = "Make";
                    buttonNext.Enabled = true;
                    break;
                case Match.STATUS.PLAYING:
                    buttonPrev.Enabled = navigator.HasPrev;
                    buttonNext.Enabled = false;
                    buttonStart.Enabled = false;
                    break;
                case Match.STATUS.DONE:
                    buttonStart.Enabled = false;
                    buttonPrev.Enabled = navigator.HasPrev;
					buttonNext.Text = navigator.HasNext ? ">>" : "Make";
                    buttonNext.Enabled = true;
                    break;
            }
			UpdateList(round);// it should be here because of "Start" problem
        }

		private class ColumnLabel {
			public string label;
			public int width;
		}

		private static ColumnLabel[] properties = new ColumnLabel[] {
            new ColumnLabel(){label ="sheet",width=42},
            new ColumnLabel(){label ="player1",width=128},
            new ColumnLabel(){label ="result",width=100},
            new ColumnLabel(){label ="player2",width=128},
            new ColumnLabel(){label ="status",width=64},
            new ColumnLabel(){label ="",width=32}
        };

		private void UpdateList(Round round) {
			tableLayoutPanelMain.Hide();
			tableLayoutPanelMain.Controls.Clear();
			if (round != null) {
				tableLayoutPanelMain.ColumnCount = properties.Length;
				tableLayoutPanelMain.RowCount = round.Count;
				foreach (var property in properties) {
					tableLayoutPanelMain.Controls.Add(new InternalLabel(property.label, property.width));
				}
				foreach (var m in round) {
					var statuslabel = new StatusLabel(m, properties[4].width);

					tableLayoutPanelMain.Controls.Add(new InternalLabel(m.id.ToString(), properties[0].width));
					tableLayoutPanelMain.Controls.Add(new InternalLabel(m.players[0].name, properties[1].width));

					var resultselector = new ResultSelector(navigator.game.IsThreePointMatch, m);
					resultselector.OnUpdate += CheckStatus;
					resultselector.OnUpdate += statuslabel.DoUpdate;
					tableLayoutPanelMain.Controls.Add(resultselector);
					tableLayoutPanelMain.Controls.Add(new InternalLabel(m.players[1].name, properties[4].width));
					tableLayoutPanelMain.Controls.Add(statuslabel);
					tableLayoutPanelMain.Controls.Add(new Label());
				}
				foreach (var property in properties) {
					tableLayoutPanelMain.Controls.Add(new InternalLabel("", property.width));
				}
			}
			tableLayoutPanelMain.Show();
		}

		private void CheckStatus() {
			OnPointChanged();
			Debug.Assert(navigator.Current!=null);
			if (navigator.Current.Status==Match.STATUS.DONE) {
				buttonNext.Text = navigator.HasNext ? ">>" : "Make";
				buttonNext.Enabled = true;
				Text = navigator.Current.Title;
			}
		}
		class InternalLabel : Label {
            public InternalLabel(string title, int width) {
                Text = title;
				Anchor = AnchorStyles.Left;
                Width = width;
            }
        }
        class StatusLabel : Label {
            Match match;
            public StatusLabel(Match match, int width) {
                Width = width;
				Anchor = AnchorStyles.Left;
				this.match = match;
                DoUpdate();
            }

            public void DoUpdate() {
                Text = match.Status.ToString();
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e) {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn) {
                SendKeys.Send("{F4}");
            }
        }
		private void buttonStart_Click(object sender, EventArgs e) {
			if (Properties.Settings.Default.isAutoSaving
				&& Properties.Settings.Default.currentFilename == "") {
				MessageBox.Show("Auto saving does not proceed. Please save the game first");
			} else {
				navigator.game.Bind(Properties.Settings.Default.isAutoSaving ? Properties.Settings.Default.currentFilename : null);
				DoUpdate();
			}
		}

		private void buttonPrev_Click(object sender, EventArgs e) {
            navigator.Prev();
        }

        private void buttonNext_Click(object sender, EventArgs e) {
            if (!navigator.Next()) {
                MessageBox.Show("Fail to create next round. you might try \"Make\" again");
            }
        }

        private void ToolStripMenuItemPrint_Click(object sender, EventArgs e) {
            if (!new PrintManager().Print(true, navigator.Current)) {// TODO Null check
                MessageBox.Show("Please check your setting. Print requires Microsoft Excel.", "Error");
            }
        }

        private void ToolStripMenuItemExcel_Click(object sender, EventArgs e) {// TODO Null check
            if (!new PrintManager().Print(false, navigator.Current)) {
                MessageBox.Show("Please check your setting. Print requires Microsoft Excel.", "Error");
            }
        }
    }
}
