using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace EMC.LL.Solutions.Adapter
{
    public class UDPListener : IListener
    {
        private UdpClient _clientListener = null;
        private IPEndPoint _groupEP = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public UDPListener()
        {
            //setting the default port
            //if port is not assigned it will take 80 as port number
            this.Port = 80;            
        }

        public int Port { get; set; }

        /// <summary>
        /// ListenPort
        /// </summary>
        /// <param name="type"></param>
        public string ListenPort()
        {
            StringBuilder sb = new StringBuilder();

            string received_data;
            byte[] receive_byte_array;

            if (_clientListener == null && _groupEP == null)
            {
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
                receive_byte_array = _clientListener.Receive(ref _groupEP);
                //sb.AppendLine("Received a broadcast from " + _groupEP.ToString());
                received_data = Encoding.ASCII.GetString(receive_byte_array, 0, receive_byte_array.Length);
                sb.AppendLine(received_data);
            }
            catch (Exception e)
            {
                sb.AppendLine(e.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// InitializeListener
        /// </summary>
        /// <param name="listener"></param>
        /// <param name="groupEP"></param>
        private void InitializeListener()
        {
            _clientListener = new UdpClient(this.Port);
            _groupEP = new IPEndPoint(IPAddress.Any, this.Port);
        }

        /// <summary>
        /// DisposeListener
        /// </summary>
        public void DisposeListener()
        {
            _clientListener.Close();
        }
    }
}
