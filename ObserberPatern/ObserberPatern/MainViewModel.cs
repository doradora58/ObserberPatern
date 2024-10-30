using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ObserberPatern
{
    public class MainViewModel : INotifyPropertyChanged , INotify,IDisposable
    {
        Dispatcher _dispatcher;
        public MainViewModel(Dispatcher dispatcher)
        {
            _dispatcher = dispatcher;
            WarningTimer.Add(this);
        }
        public void Dispose()
        {
            WarningTimer.Remove(this);
        }

        private string _warningLabelText = "aaa";
        public event PropertyChangedEventHandler PropertyChanged;

        public string WarningLabelText {
            get
            {
                return _warningLabelText;
            }
            set
            {
                if (_warningLabelText != value)
                {
                    _warningLabelText = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WarningLabelText"));
                }
            }
        }

        public void Update(bool isWarning)
        {
            _dispatcher.Invoke((Action)delegate ()
            {
                if (isWarning)
                {
                    WarningLabelText = "Warning";
                    //WarningLabelTesxt.BackColor = Color.Red;
                }
                else
                {
                    WarningLabelText = "Normal";
                    //WarningLabelTesxt.BackColor = Color.Lime;
                }
            });
        }


    }
}
