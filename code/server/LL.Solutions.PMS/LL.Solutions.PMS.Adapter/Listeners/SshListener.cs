using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LL.Solutions.Adapter;
using Renci.SshNet;

namespace LL.Solutions.PMS.Adapter
{
    public class SshListener : IListener
    {
        #region Members
        private SshClient _sshClient = null;
        private ConnectionInfo _connInfo = null;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public SshListener()
        {
            //setting the default port
            //if port is not assigned it will take 80 as port number
            Constants.log.Info("Setting default port to 22!");
            this.Port = 22;
        }
        #endregion

        #region Properties
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public string Path { get; set; }

        public string Command { get; set; }

        public int Port { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// ListenPort
        /// </summary>
        /// <returns></returns>
        public string ListenPort()
        {
            Constants.log.Info("Entering SshListener ListenPort Method!");
            string response = string.Empty;

            if (_sshClient == null && _connInfo == null)
            {
                Constants.log.Info("Calling SshListener InitializeListener Method!");
                InitializeListener();
            }

            try
            {
                _sshClient = new SshClient(_connInfo);
                _sshClient.Connect();
                response = _sshClient.CreateCommand(this.Command).Execute();
            }
            catch (Exception ex)
            {
                Constants.log.Error(ex.Message);
                response = ex.Message;
            }

            Constants.log.Info("Exiting SshListener ListenPort Method!");
            return response;
        }

        /// <summary>
        /// InitializeListener
        /// </summary>
        private void InitializeListener()
        {
            Constants.log.Info("Entering SshListener InitializeListener Method!");
            // Setup Credentials and Server Information
            _connInfo = new ConnectionInfo(this.Address, this.Port, this.UserName,
                new AuthenticationMethod[]
                {
                    // Pasword based Authentication
                    new PasswordAuthenticationMethod(this.UserName,this.Password),
                }
            );

            Constants.log.Info("Exiting SshListener InitializeListener Method!");
        }

        /// <summary>
        /// DisposeListener
        /// </summary>
        public void DisposeListener()
        {
            Constants.log.Info("Entering SshListener DisposeListener Method!");
            _sshClient.Disconnect();
            Constants.log.Info("Entering SshListener DisposeListener Method!");
        } 
        #endregion
    }
}
