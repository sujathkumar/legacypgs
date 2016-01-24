using EMC.LL.Solutions.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LL.Solutions.PMS.Service
{
    public class ListenerService
    {
        private IListener _listener = null;

        /// <summary>
        /// StartService
        /// </summary>
        public void StartService(string listener, int port)
        {
            if (listener == "UDP")
            {
                _listener = new UDPListener();
                _listener.Port = port;
            }
        }

        /// <summary>
        /// ListenService
        /// </summary>
        /// <returns></returns>
        public string ListenService()
        {
            return _listener.ListenPort();
        }

        /// <summary>
        /// StopService
        /// </summary>
        public void StopService()
        {
            _listener.DisposeListener();
        }
    }
}
