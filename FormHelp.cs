using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace BSMatchMaker
{
    public partial class FormHelp : Form
    {
        public FormHelp()
        {
            InitializeComponent();
            var buf = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\BSMatchMakerManual.pdf";
            webBrowserMain.Navigate(buf);
        }
    }
}
