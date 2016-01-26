using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;

namespace LL.Solutions.PMS.Adapter
{
    public class SshListener : IListener
    {
        private SshClient _sshClient = null;
        private ConnectionInfo _connInfo = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public SshListener()
        {
            //setting the default port
            //if port is not assigned it will take 80 as port number
            this.Port = 22;
        }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public string Path { get; set; }

        public string Command { get; set; }

        public int Port { get; set; }

        /// <summary>
        /// ListenPort
        /// </summary>
        /// <returns></returns>
        public string ListenPort()
        {
            string response = string.Empty;

            if (_sshClient == null && _connInfo == null)
            {
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
                response = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// InitializeListener
        /// </summary>
        private void InitializeListener()
        {
            // Setup Credentials and Server Information
            _connInfo = new ConnectionInfo(this.Address, this.Port, this.UserName,
                new AuthenticationMethod[]
                {
                    // Pasword based Authentication
                    new PasswordAuthenticationMethod(this.UserName,this.Password),
                }
            );
        }

        /// <summary>
        /// DisposeListener
        /// </summary>
        public void DisposeListener()
        {
            _sshClient.Disconnect();
        }
    }
}
