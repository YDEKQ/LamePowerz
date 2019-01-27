using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LamePowerz
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();

            Program.AllForms.Add(this);
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Do you really want to quit? Press No to hide all windows", "LamePowerz", MessageBoxButtons.YesNoCancel, MessageBoxIcons.None);

            if (result == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else if (result == DialogResult.No)
            {
                e.Cancel = true;

                foreach (var wnd in Program.AllForms)
                    wnd.Hide();
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
