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
    public partial class SubForm : Form
    {
        public SubForm()
        {
            InitializeComponent();
            this.Disposed += SubForm_Disposed;
            StartPosition = FormStartPosition.CenterScreen;
            WarningTimer.Add(WarningTimer_WarningAction);
        }

        private void SubForm_Disposed(object sender, EventArgs e)
        {
            WarningTimer.Remove(WarningTimer_WarningAction);
        }

        private void WarningTimer_WarningAction(bool isWarning)
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
