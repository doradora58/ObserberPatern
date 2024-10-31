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
        WarningTimerBase _warningTimerBase;
        Dispatcher _dispatcher;
        public MainViewModel(Dispatcher dispatcher, WarningTimerBase warningTimerBase)
        {
            _dispatcher = dispatcher;
            _warningTimerBase = warningTimerBase;
            _warningTimerBase.Add(this);
        }
        public void Dispose()
        {
            _warningTimerBase.Remove(this);
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
                    if (_dispatcher == null)
                    {

                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WarningLabelText"));
                    }
                    else
                    {
                        _dispatcher.Invoke((Action)delegate ()
                        {
                            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WarningLabelText"));
                        });
                    }
                }
            }
        }

        public void Update(bool isWarning)
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
        }


    }
}
