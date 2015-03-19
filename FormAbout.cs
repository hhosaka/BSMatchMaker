using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace BSMatchMaker {
	public partial class FormAbout : Form {
		public FormAbout() {
			InitializeComponent();
			labelAppName.Text = ((AssemblyTitleAttribute)Attribute.GetCustomAttribute(
							Assembly.GetExecutingAssembly(), 
							typeof(System.Reflection.AssemblyTitleAttribute))).Title;

			labelCompany.Text = ((AssemblyCompanyAttribute)Attribute.GetCustomAttribute(
							Assembly.GetExecutingAssembly(),
							typeof(AssemblyCompanyAttribute))).Company;

			labelCopyright.Text = ((AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(
							Assembly.GetExecutingAssembly(),
							typeof(AssemblyCopyrightAttribute))).Copyright;

			labelAppVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
		}
	}
}
