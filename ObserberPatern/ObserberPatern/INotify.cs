using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserberPatern
{
    public interface INotify
    {
        void Update(bool isNotify);
    }
}
