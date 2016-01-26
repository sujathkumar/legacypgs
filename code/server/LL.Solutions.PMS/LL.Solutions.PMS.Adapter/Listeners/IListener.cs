using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LL.Solutions.PMS.Adapter
{
    public interface IListener
    {
        string UserName { get; set; }

        string Password { get; set; }

        string Address { get; set; }

        string Path { get; set; }

        string Command { get; set; }

        int Port { get; set; }

        string ListenPort();

        void DisposeListener();
    }
}
