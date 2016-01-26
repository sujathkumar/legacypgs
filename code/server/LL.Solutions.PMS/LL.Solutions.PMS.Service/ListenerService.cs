using LL.Solutions.PMS.Adapter;
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
        public void StartService(string listener, string userName = "", string password = "", string address = "", string path = "", string command = "", int port = 0)
        {
            if (listener == "UDP")
            {
                _listener = new UdpListener();
            }
            else if (listener == "SSH")
            {
                _listener = new SshListener();
            }
            else if (listener == "SCP")
            {
                _listener = new ScpListener();
            }

            _listener.UserName = userName;
            _listener.Password = password;
            _listener.Address = address;
            _listener.Path = path;
            _listener.Command = command;
            _listener.Port = port;
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
