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
        #endregion

        #region Getter/Setter
        public TcpListener Server { get => _server; set => _server = value; }
        public TcpClient Self { get => _self; set => _self = value; }
        public int Port { get => _port; set => _port = value; }
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
        }

        private void runServer()
        {
            bool bedingung = true;
            this.Server.Start();
            while (bedingung)
            {
                try
                {
                    this.Self = this.Server.AcceptTcpClient();
                    Console.WriteLine("Connected to: " + this.Self.Client.LocalEndPoint);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message+ "/ press any key to exit...");
                    Console.Read();
                    bedingung = false;
                }
            }
        } 
        
	    #endregion
    }
}
