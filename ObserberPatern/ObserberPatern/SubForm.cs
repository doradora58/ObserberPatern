using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObserberPatern
{
    public partial class SubForm : Form, INotify
    {
        public SubForm()
        {
            InitializeComponent();
            this.Disposed += SubForm_Disposed;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void SubForm_Disposed(object sender, EventArgs e)
        {
            Program.WarningTimer.Remove(this);
        }

        //private void WarningTimer_WarningAction(bool isWarning)
        //{


        //}

        private void autoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (autoUpdate.Checked)
            {
                Program.WarningTimer.Add(this);
            }
            else
            {
                Program.WarningTimer.Remove(this);

            }
        }

        public void Update(bool isWarning)
        {
            this.Invoke((Action)delegate ()
            {
                if (isWarning)
                {
                    label2.Text = "Warning";
                    label2.BackColor = Color.Red;
                }
                else
                {
                    label2.Text = "Normal";
                    label2.BackColor = Color.Lime;
                }
            });
        }
    }
}
