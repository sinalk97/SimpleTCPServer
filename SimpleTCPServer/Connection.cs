using System;
using System.Collections.Generic;
using System.Linq;
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
            this.Server = new TcpListener(port);
        }
        #endregion
    }
}
