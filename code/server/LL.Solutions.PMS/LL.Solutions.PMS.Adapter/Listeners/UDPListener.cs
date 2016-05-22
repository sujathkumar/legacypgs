using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using LL.Solutions.Adapter;

namespace LL.Solutions.PMS.Adapter
{
    public class UdpListener : IListener
    {
        #region Members
        private UdpClient _clientListener = null;
        private IPEndPoint _groupEP = null;
        Random random = new Random();
        StringBuilder sb = new StringBuilder();
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public UdpListener()
        {
            //setting the default port
            //if port is not assigned it will take 80 as port number
            Constants.log.Info("Setting default port to 22!");
            this.Port = 80;
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
        public string ListenPort()
        {
            Constants.log.Info("Entering UdpListener ListenPort Method!");
            sb.Clear();

            if (_clientListener == null && _groupEP == null)
            {
                Constants.log.Info("Calling UdpListener InitializeListener Method!");
                InitializeListener();
            }

            try
            {
                //sb.AppendLine("Waiting for broadcast");
                // this is the line of code that receives the broadcase message.
                // It calls the receive function from the object listener (class UdpClient)
                // It passes to listener the end point groupEP.
                // It puts the data from the broadcast message into the byte array
                // named received_byte_array.
                // I don't know why this uses the class UdpClient and IPEndPoint like this.
                // Contrast this with the talker code. It does not pass by reference.
                // Note that this is a synchronous or blocking call.

                Thread t = new Thread(Receive);
                t.Start();

                if (!t.Join(TimeSpan.FromSeconds(10)))
                {
                    t.Abort();
                    throw new Exception("System Exception: More than 10 secs.");
                }

                //sb.Append("Level");
                //sb.Append(random.Next(1, 4).ToString());
                //sb.Append("-Alive");
            }
            catch (Exception ex)
            {
                Constants.log.Error(ex.Message);
                sb.AppendLine(ex.ToString());
            }

            Constants.log.Info("Exiting UdpListener ListenPort Method!");
            return sb.ToString();
        }

        private void Receive()
        {
            try
            {
                Constants.log.Info("Entering UdpListener Receive Method!");
                string received_data;
                byte[] receive_byte_array;

                receive_byte_array = _clientListener.Receive(ref _groupEP);
                //sb.AppendLine("Received a broadcast from " + _groupEP.ToString());
                received_data = Encoding.ASCII.GetString(receive_byte_array, 0, receive_byte_array.Length);

                sb.AppendLine(received_data);
                Constants.log.Info("Exiting UdpListener Receive Method!");
            }
            catch (ThreadAbortException ex)
            {
                Constants.log.Error(ex.Message);
            }
        }

        /// <summary>
        /// InitializeListener
        /// </summary>
        private void InitializeListener()
        {
            try
            {
                Constants.log.Info("Entering UdpListener InitializeListener Method!");
                _clientListener = new UdpClient(this.Port);
                _groupEP = new IPEndPoint(IPAddress.Any, this.Port);
                Constants.log.Info("Exiting UdpListener InitializeListener Method!");
            }
            catch(Exception ex)
            {
                Constants.log.Error(ex.Message);
            }
        }

        /// <summary>
        /// DisposeListener
        /// </summary>
        public void DisposeListener()
        {
            Constants.log.Info("Entering UdpListener DisposeListener Method!");
            _clientListener.Close();
            Constants.log.Info("Exiting UdpListener DisposeListener Method!");
        } 
        #endregion
    }
}
