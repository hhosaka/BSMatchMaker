using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace BSMatchMaker {
    public partial class FormMain : Form {
		Game game;
        private FormMatchList matchlist;

		public FormMain() {
            InitializeComponent();

            initList();

			game = new Game();
			autoSavingToolStripMenuItem.Checked = Properties.Settings.Default.isAutoSaving;
			showPercentageToolStripMenuItem.Checked = Properties.Settings.Default.isShowPercentage;
			Properties.Settings.Default.currentFilename = "";
			Properties.Settings.Default.Save();
		}

		private ColumnHeader createHeader(string title, int width) {
            var ret = new ColumnHeader();
            ret.Text = title;
            ret.Width = width;
            return ret;
        }

        private void initList() {
            listViewMain.Columns.AddRange(new ColumnHeader[] {
                createHeader("Name",192),
                createHeader("Rank",64),
                createHeader("MatchP",64),
                createHeader("OpponentP",64),
                createHeader("WinP",64)
                });
        }

        private void DoUpdate() {
			listViewMain.Items.Clear();
			foreach (var player in game.SortByRank) {
				var item = new ListViewItem(new string[] { player.name, player.rank.ToString(), player.GetMatchResult(Properties.Settings.Default.isShowPercentage).ToString(), player.OpponentPercentage.ToString(), player.WinPoint.ToString() });
				item.Tag = player;
				if (player.Dropped) { item.Font = new Font(item.Font.FontFamily, item.Font.Size, FontStyle.Strikeout); }
				listViewMain.Items.Add(item);
			}
			toolStripMenuItemPrint.Enabled = game.Players.Length > 0;
			toolStripMenuItemExcel.Enabled = game.Players.Length > 0;
			dropToolStripMenuItem.Enabled = game.Players.Length > 0;
			seedToolStripMenuItem.Enabled = false;
			buttonMatch.Enabled = game.Players.Length > 0;
        }

        private void toolStripMenuItemNew_Click(object sender, EventArgs e) {
            var dlg = new FormInitialize();
            if (dlg.ShowDialog() == DialogResult.OK) {
                game = dlg.Game;
				DoUpdate();
				if (matchlist != null) {
					matchlist.Close();
					matchlist = null;
				}
				matchToolStripMenuItem.Enabled = game.Players.Length > 0;
				Properties.Settings.Default.currentFilename = "";
				Properties.Settings.Default.Save();
				toolStripMenuSave.Enabled = true;
				toolStripMenuItemSaveAs.Enabled = true;
			}
        }

        private void ToolStripMenuItemOpen_Click(object sender, EventArgs e) {
            var dlg = new OpenFileDialog();
			dlg.DefaultExt = ".bsmdata";
			dlg.Filter = "BS Match Maker Data files (*.bsmdata)|*.bsmdata|All files (*.*)|*.*";
			if (dlg.ShowDialog() == DialogResult.OK) {
				if (Game.Load(dlg.FileName, ref game)) {
					DoUpdate();
					if (matchlist != null) {
						matchlist.Close();
						matchlist = null;
					}
					matchToolStripMenuItem.Enabled = game.Players.Length > 0;
					Properties.Settings.Default.currentFilename = dlg.FileName;
					Properties.Settings.Default.Save();
					toolStripMenuSave.Enabled = true;
					toolStripMenuItemSaveAs.Enabled = true;
				}
			}
        }

        private void toolStripMenuSave_Click(object sender, EventArgs e) {
			if (Properties.Settings.Default.currentFilename != "") {
				Game.Save(Properties.Settings.Default.currentFilename, game);
			} else {
				toolStripMenuItemSaveAs_Click(sender, e);
			}
        }

		private void toolStripMenuItemSaveAs_Click(object sender, EventArgs e) {
			var dlg = new SaveFileDialog();
			dlg.DefaultExt = ".bsmdata";
			dlg.Filter = "BS Match Maker Data files (*.bsmdata)|*.bsmdata|All files (*.*)|*.*";
			if (dlg.ShowDialog() == DialogResult.OK) {
				Game.Save(dlg.FileName, game);
				Properties.Settings.Default.currentFilename = dlg.FileName;
				Properties.Settings.Default.Save();
			}
		}

        private void toolStripMenuItemPrint_Click(object sender, EventArgs e) {
			new PrintManager().Print(true, game.Players);
		}

		private void toolStripMenuItemExcel_Click(object sender, EventArgs e) {
			new PrintManager().Print(false, game.Players);
		}
		
		private void usageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormHelp().Show();
        }

		private void matchToolStripMenuItem_Click(object sender, EventArgs e) {
			if (matchlist == null) {
				matchlist = new FormMatchList(game);
				matchlist.OnPointChanged += DoUpdate;
				matchlist.FormClosing += (arg1, arg2) => { matchlist = null; };
				matchlist.Show();
			} else {
				matchlist.Activate();
			}
		}

		private void dropToolStripMenuItem_Click(object sender, EventArgs e) {
			var dlg = new FormDrop(game.Players);
			dlg.ShowDialog();
			if(dlg.Modified){
				game.Reset();
				DoUpdate();
			}
		}
		private void MatchMakerToolStripMenuItemAbout_Click(object sender, EventArgs e) {
			new FormAbout().ShowDialog();
		}

		private void buttonMatch_Click(object sender, EventArgs e) {
			matchToolStripMenuItem_Click(sender, e);
		}

		private void toolStripMenuItemSupport_Click(object sender, EventArgs e) {
			Process.Start("https://code.google.com/p/bs-match-maker/");
		}

		private void autoSavingToolStripMenuItem_Click(object sender, EventArgs e) {
			Properties.Settings.Default.isAutoSaving = ((ToolStripMenuItem)sender).Checked;
			Properties.Settings.Default.Save();
		}

		private void showPercentageToolStripMenuItem_Click(object sender, EventArgs e) {
			Properties.Settings.Default.isShowPercentage = ((ToolStripMenuItem)sender).Checked;
			Properties.Settings.Default.Save();
			DoUpdate();
		}
	}
}
