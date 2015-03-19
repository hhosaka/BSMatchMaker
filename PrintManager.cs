using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace BSMatchMaker {
    class PrintManager {
		private class ColumnProperty {
			public string title;
			public int width;

			public ColumnProperty(string title, int width) {
				this.title = title;
				this.width = width;
			}
		}

		private interface PrintContents {
			int Length {
				get;
			}
			ColumnProperty[] GetProperties();
			void PrintRecord(Worksheet sheet, int i);
		}

		private class PrintRound : PrintContents {

			private Round round;

			public PrintRound(Round round){
				this.round = round;
			}

			public int Length {
				get { return round.Count; }
			}

			public ColumnProperty[] GetProperties() {
				var ret = new ColumnProperty[]{
					new ColumnProperty("SHEET",5),
					new ColumnProperty("PLAYER1",30),
					new ColumnProperty("POINT",5),
					new ColumnProperty("PLAYER2",30),
					new ColumnProperty("POINT",5)
				};
				return ret;
			}

			public void PrintRecord(Worksheet sheet, int i) {
				var range = (Range)sheet.Range[sheet.Cells[i + 2, 1], sheet.Cells[i + 2, 5]];
				if (i % 2 == 1) { range.Interior.Color = 0xCCCCCC; }
				range.Borders.LineStyle = XlLineStyle.xlContinuous;
				range[1, 1] = round[i].id;
				range[1, 2] = round[i].players[0].name;
				range[1, 3] = round[i].players[0].GetMatchResult(Properties.Settings.Default.isShowPercentage);
				range[1, 4] = round[i].players[1].name;
				range[1, 5] = round[i].players[1].GetMatchResult(Properties.Settings.Default.isShowPercentage);
			}
		}

		private class PrintPlayers : PrintContents {
			public Player[] players;
			public int Length {
				get {
					return players.Length;
				}
			}

			public PrintPlayers(Player[] players) {
				this.players = players;
			}

			public ColumnProperty[] GetProperties() {
				var ret = new ColumnProperty[]{
					new ColumnProperty("RANK",5),
					new ColumnProperty("ID",5),
					new ColumnProperty("NAME",30),
					new ColumnProperty("MATCH",10),
					new ColumnProperty("OPPONENT",10),
					new ColumnProperty("WIN",10)
				};
				return ret;
			}

			public void PrintRecord(Worksheet sheet, int i) {
				var range = (Range)sheet.Range[sheet.Cells[i + 2, 1], sheet.Cells[i + 2, 6]];
				if (i % 2 == 1) { range.Interior.Color = 0xCCCCCC; }
				range.Borders.LineStyle = XlLineStyle.xlContinuous;
				range[1, 1] = players[i].rank;
				range[1, 2] = players[i].id;
				range[1, 3] = players[i].name;
				range[1, 4] = players[i].GetMatchResult(Properties.Settings.Default.isShowPercentage);
				range[1, 5] = players[i].OpponentPoint;
				range[1, 6] = players[i].WinPoint;
			}
		}

		public bool Print(bool direct, Player[]players) {
			return Print(direct, new PrintPlayers(players));
		}

		public bool Print(bool direct, Round round) {
			return Print(direct, new PrintRound(round));
		}

		private bool Print(bool direct, PrintContents contents) {
			try {
				var excel = new Microsoft.Office.Interop.Excel.Application();
				try {
					excel.Visible = false;
					var book = (Workbook)excel.Workbooks.Add();
					Worksheet sheet = (Worksheet)book.Sheets[1];
					PrintIndex(sheet, contents);
					PrintRecord(contents, sheet);
					if (direct) {
						sheet.PrintOut(1, 1, 1, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
					} else {
						excel.Visible = true;
					}
					return true;
				} catch {
					return false;
				} finally {
					excel.Quit();
				}
			} catch {
				return false;
			}
		}

		private void PrintIndex(Worksheet sheet, PrintContents contents) {
			int col = 0;
			foreach (var property in contents.GetProperties()) {
				var range = (Range)sheet.Cells[1, ++col];
				range.ColumnWidth = property.width;
				range.Value = property.title;
				range.Interior.Color = 0x000000;
				range.Font.Color = 0xffffff;
			}
		}

		private void PrintRecord(PrintContents contents, Worksheet sheet) {
			for (int i = 0; i < contents.Length; ++i) {
				contents.PrintRecord(sheet, i);
			}
		}
    }
}
