using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BSMatchMaker {
	public partial class FormDrop : Form {
		public bool Modified = false;

		public FormDrop(Player[] players) {
			InitializeComponent();
			listViewMain.ItemChecked += setDroped;
			foreach (var player in players) {
				var item = new ListViewItem(player.name);
				item.Tag = player;
				item.Checked = player.Dropped;
				listViewMain.Items.Add(item);
			}
		}

		private void setDroped(object sender, ItemCheckedEventArgs e) {
			((Player)e.Item.Tag).Dropped = e.Item.Checked;
			Modified = true;
		}

	}
}
