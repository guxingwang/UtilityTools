using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenOtherApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.txtFilePath.Text = Properties.Settings.Default.FilePath;
            this.txtParameter.Text = Properties.Settings.Default.Parameter;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txtFilePath.Text.Trim()))
            {
                Properties.Settings.Default.FilePath = this.txtFilePath.Text.Trim();
                Properties.Settings.Default.Parameter = this.txtParameter.Text.Trim();
                Properties.Settings.Default.Save();

                System.Diagnostics.Process.Start(Properties.Settings.Default.FilePath, Properties.Settings.Default.Parameter);
            }
            
        }
    }
}
