using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObserberPatern
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            timer1.Interval = 5000;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (WarningTimer.IsWarning)
            {
                label1.Text = "Warning";
                label1.BackColor = Color.Red;
            }
            else
            {
                label1.Text = "Normal";
                label1.BackColor = Color.Lime;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new SubForm();
            f.Show();
        }
    }
}
