using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserberPatern
{
    public abstract class WarningTimerBase
    {

        private List<INotify> _notifies = new List<INotify>();

        private bool _isWarning = false;
        public bool IsWarning
        {
            get
            { return _isWarning; }
            protected set
            {
                if (_isWarning != value)
                {
                    _isWarning = value;
                    //_notifies?.Invoke(value);
                    foreach (var notify in _notifies)
                    {
                        notify.Update(value);
                    }
                }
            }
        }
        public void Add(INotify notify)
        {
            //bool contains = false;
            //if(_notifies != null)
            //{
            //    contains = _notifies.GetInvocationList().Contains(action);
            //}
            if (!_notifies.Contains(notify))
            {

                _notifies.Add(notify);
            }
        }

        public void Remove(INotify notify)
        {
            _notifies.Remove(notify);
        }
    }
}
