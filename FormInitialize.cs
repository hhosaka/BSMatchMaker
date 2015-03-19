using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace BSMatchMaker {
    public partial class FormInitialize : Form {

        public FormInitialize() {
            InitializeComponent();
        }

        internal Game Game {
            get;
            private set;
        }

        private void radioButtonGenerate_Click(object sender, EventArgs e) {
            numericUpDownPlayer.Enabled = true;
        }

        private void radioButtonImport_Click(object sender, EventArgs e) {
            numericUpDownPlayer.Enabled = false;
        }

        private void buttonOK_Click(object sender, EventArgs args) {
            try {
				Game = null;
                if (radioButtonGenerate.Checked) {
                    Debug.Assert((int)numericUpDownPlayer.Value>1);
                    Game = new Game(GeneratePlayers((int)numericUpDownPlayer.Value),radioButtonThreePoint.Checked);
                } else {
                    var dlg = new OpenFileDialog();
					dlg.Filter = "Excel files (*.xlsx,*.xlsm,*.xls)|*.xlsx;*.xlsm;*.xls|Text files (*.txt)|*.txt|All files (*.*)|*.*";
					if (dlg.ShowDialog() == DialogResult.OK) {
                        using (var e = CreateEnumerator(dlg.FileName)) {
							Game = new Game(CreatePlayers(e), radioButtonThreePoint.Checked);
                        }
                    }
                }
				if (Game != null) {
					DialogResult = DialogResult.OK;
				}
            } catch {
                MessageBox.Show("Fail to make game");
            }
        }

        private static Player[] CreatePlayers(IEnumerator<string> e) {
            var ret = new List<Player>();

            int id = 0;
            while (e.MoveNext()) {
                ret.Add(new Player(++id, e.Current));
            }
            return ret.ToArray();
        }

        private static Player[] GeneratePlayers(int count) {
            var ret = new List<Player>();
            for (int i = 0; i < count; ++i) {
                ret.Add(new Player(i + 1, "Player" + (i + 1).ToString("D03")));
            }
            return ret.ToArray();
        }

        private IEnumerator<string> CreateEnumerator(string filename) {
            switch (Path.GetExtension(filename)) {
                case ".xlsx":
                    return new ExcelEnumerator(filename);
                case ".txt":
                    return new TextEnumerator(filename);
                default:
                    throw new NotSupportedException("Unsupported file format");
            }
        }

        private class TextEnumerator : IEnumerator<string> {
            private TextReader reader;

            public TextEnumerator(string filename) {
                reader = new StreamReader(filename, Encoding.GetEncoding("Shift_JIS"));
            }

            public string Current {
                get;
                private set;
            }

            public void Dispose() {
                reader.Close();
            }

            object System.Collections.IEnumerator.Current {
                get { throw new NotImplementedException(); }
            }

            public bool MoveNext() {
                Current = reader.ReadLine();
                return Current != null;
            }

            public void Reset() {
                throw new NotImplementedException();
            }
        }

        class ExcelEnumerator : IEnumerator<string> {
            private int pos = 0;
			private Microsoft.Office.Interop.Excel.Application excel = null;
            private Workbook book;
            Worksheet sheet;

            public ExcelEnumerator(string filename) {
                try{
                    excel = new Microsoft.Office.Interop.Excel.Application();
                    excel.Visible = false;
                    book = (Workbook)(excel.Workbooks.Open(
                        filename,
                        Type.Missing, // （省略可能）UpdateLinks (0 / 1 / 2 / 3)
                        Type.Missing, // （省略可能）ReadOnly (True / False )
                        Type.Missing, // （省略可能）Format
                        Type.Missing, // （省略可能）Password
                        Type.Missing, // （省略可能）WriteResPassword
                        Type.Missing, // （省略可能）IgnoreReadOnlyRecommended
                        Type.Missing, // （省略可能）Origin
                        Type.Missing, // （省略可能）Delimiter
                        Type.Missing, // （省略可能）Editable
                        Type.Missing, // （省略可能）Notify
                        Type.Missing, // （省略可能）Converter
                        Type.Missing, // （省略可能）AddToMru
                        Type.Missing, // （省略可能）Local
                        Type.Missing  // （省略可能）CorruptLoad
                    ));
                    sheet = (Worksheet)book.Sheets["Entry Sheet"];
                }catch{
                }
            }

            public string Current {
                get;
                private set;
            }

            public void Dispose() {
                if(book!=null){
                    book.Close();
					excel.Quit();
                }
            }

            object System.Collections.IEnumerator.Current {
                get { throw new NotImplementedException(); }
            }

            public bool MoveNext() {
                Current = ((Range)sheet.Cells[(++pos) + 1, 1]).Text.ToString();
                return Current != "";
            }

            public void Reset() {
                pos = 0;
            }
        }
    }
}
