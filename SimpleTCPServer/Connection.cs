using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SimpleTCPServer
{
    public class Connection
    {
        #region Properties
        private TcpListener _server;
        private TcpClient _self;
        private int _port;
        private bool _isServerRunning;
        #endregion

        #region Getter/Setter
        public TcpListener Server { get => _server; set => _server = value; }
        public TcpClient Self { get => _self; set => _self = value; }
        public int Port { get => _port; set => _port = value; }
        public bool IsServerRunning { get => _isServerRunning; set => _isServerRunning = value; }
        #endregion

        #region Constructors
        public Connection(int port)

        {
            this.Server = new TcpListener(IPAddress.Any, port);
        }


        #endregion

        #region Workers
        public void startServer()
        {
            Thread serverThread = new Thread(new ThreadStart(runServer));
            serverThread.Start();
            Thread.Sleep(200);

        }

        public void getData()
        {
            while (IsServerRunning)
            {
                string receivedString = "";
                NetworkStream networkStream = this.Self.GetStream();
                byte[] buffer = new byte[8192];
                networkStream.Read(buffer, 0, buffer.Length);
                receivedString = Encoding.UTF8.GetString(buffer);
                Console.Clear();
                Console.WriteLine(receivedString);
                Console.SetCursorPosition(0,0);
                this.sendToAll(receivedString);
            }

        }

        public void sendToAll(string value)
        {
            NetworkStream networkStream = this.Self.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes(value);
            networkStream.Write(buffer, 0, buffer.Length);
        }

        private void runServer()
        {
            
            this.IsServerRunning = true;
            this.Server.Start();
            while (IsServerRunning)
            {
                try
                {
                    this.Self = this.Server.AcceptTcpClient();
                    Console.WriteLine(" new connection from: " + this.Self.Client.LocalEndPoint);
                    Console.WriteLine("//////Begin Reading....");
                    Thread receiver = new Thread(new ThreadStart(getData));
                    receiver.Start();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message+ "/ press any key to exit...");
                    Console.Read();
                    IsServerRunning = false;
                }
            }
        } 
        
	    #endregion
    }
}
