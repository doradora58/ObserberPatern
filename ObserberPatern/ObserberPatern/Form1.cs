using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace ObserberPatern
{
    public partial class Form1 : Form
    {
        private MainViewModel _vm = new MainViewModel(Dispatcher.CurrentDispatcher, Program.WarningTimer);
        public Form1()
        {
            InitializeComponent();
            this.Disposed += Form1_Disposed;
            StartPosition = FormStartPosition.CenterScreen;

            label1.DataBindings.Add("Text", _vm, nameof(_vm.WarningLabelText));
        }

        private void Form1_Disposed(object sender, EventArgs e)
        {
            _vm?.Dispose();
        }

        //private void WarningTimer_WarningAction(bool isWarning)
        //{


        //}

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new SubForm();
            f.Show();
        }

        ////private void autoUpdate_CheckedChanged(object sender, EventArgs e)
        ////{
        ////    if (autoUpdate.Checked)
        ////    {
        ////        WarningTimer.Add(this);
        ////    }
        ////    else
        ////    {
        ////        WarningTimer.Remove(this);

        ////    }
        ////}


    }
}