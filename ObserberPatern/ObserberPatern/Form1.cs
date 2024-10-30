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
    public partial class Form1 : Form,INotify
    {
        public Form1()
        {
            InitializeComponent();
            this.Disposed += Form1_Disposed;
            StartPosition = FormStartPosition.CenterScreen;

            WarningTimer.Add(this);
        }

        private void Form1_Disposed(object sender, EventArgs e)
        {
            WarningTimer.Remove(this);
        }

        //private void WarningTimer_WarningAction(bool isWarning)
        //{


        //}

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new SubForm();
            f.Show();
        }

        private void autoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (autoUpdate.Checked)
            {
                WarningTimer.Add(this);
            }
            else
            {
                WarningTimer.Remove(this);

            }
        }

        public void Update(bool isWarning)
        {
            this.Invoke((Action)delegate ()
            {
                if (isWarning)
                {
                    label1.Text = "Warning";
                    label1.BackColor = Color.Red;
                }
                else
                {
                    label1.Text = "Normal";
                    label1.BackColor = Color.Lime;
                }
            });
        }
    }
}