using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserberPatern
{
    public static class WarningTimer
    {
        private static System.Threading.Timer _timer;
        private static event Action<bool> _warningAction;


        static WarningTimer() 
        {
            _timer = new System.Threading.Timer(TimerCallback);
        }

        private static bool _isWarning = false; 
        public static bool IsWarning
        {
            get
            { return _isWarning; }
            private set
            {
                if (_isWarning != value)
                {
                    _isWarning = value;
                    _warningAction?.Invoke(value);
                }
            }
        }
        public static void Add(Action<bool> action)
        {
            bool contains = false;
            if(_warningAction != null)
            {
                contains = _warningAction.GetInvocationList().Contains(action)
            }
            if (!contains)
            {

                _warningAction += action;
            }
        }

        public static void Remove(Action<bool> action)
        {
            _warningAction -= action;
        }
        public static void Start()
        {
            _timer.Change(0, 5000);
        }
        private static void TimerCallback(object state)
        {
            var lines = System.IO.File.ReadAllLines("warning.txt");
            if(lines.Length > 0)
            {
                IsWarning = lines[0] == "1";
                return;
            }
            IsWarning = false;
        }
    }

}
