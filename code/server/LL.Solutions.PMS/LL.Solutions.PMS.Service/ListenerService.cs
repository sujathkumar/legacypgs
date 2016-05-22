using LL.Solutions.PMS.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LL.Solutions.PMS.Service
{
    public class ListenerService : IService
    {
        #region Members
        private IListener _listener = null;
        #endregion

        #region Properties
        /// <summary>
        /// DisplayName
        /// </summary>
        public string DisplayName
        {
            get
            {
                return "ListenerService";
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// StartService
        /// </summary>
        public void StartService(string listener, string userName = "", string password = "", string address = "", string path = "", string command = "", int port = 0)
        {
            try
            {
                Constants.log.Info("Entering Listener Service StartService Method!");
                if (listener == Constants.UDP)
                {
                    Constants.log.Info("Calling UDP Listener");
                    _listener = new UdpListener();
                }
                else if (listener == Constants.SSH)
                {
                    Constants.log.Info("Calling SSH Listener");
                    _listener = new SshListener();
                }
                else if (listener == Constants.SCP)
                {
                    Constants.log.Info("Calling SCP Listener");
                    _listener = new ScpListener();
                }

                _listener.UserName = userName;
                _listener.Password = password;
                _listener.Address = address;
                _listener.Path = path;
                _listener.Command = command;
                _listener.Port = port;

                Constants.log.Info("Exiting Listener Service StartService Method!");
            }
            catch(Exception ex)
            {
                Constants.log.Error(ex.Message);
            }
        }

        /// <summary>
        /// ListenService
        /// </summary>
        /// <returns></returns>
        public string ListenService()
        {
            string data = null;
            try
            {
                Constants.log.Info("Entering Listener Service ListenService Method!");
                data = _listener.ListenPort();
                Constants.log.Info("Entering Listener Service ListenService Method!");
            }
            catch(Exception ex)
            {
                Constants.log.Error(ex.Message);
            }

            return data;
        }

        /// <summary>
        /// StopService
        /// </summary>
        public void StopService()
        {
            try
            {
                Constants.log.Info("Entering Listener Service StopService Method!");
                _listener.DisposeListener();
                Constants.log.Info("Entering Listener Service StopService Method!");
            }
            catch (Exception ex)
            {
                Constants.log.Error(ex.Message);
            }
        } 
        #endregion
    }
}
