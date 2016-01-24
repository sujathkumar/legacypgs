using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMC.LL.Solutions.Adapter
{
    public interface IListener
    {
        int Port { get; set; }
        string ListenPort();
        void DisposeListener();
    }
}
