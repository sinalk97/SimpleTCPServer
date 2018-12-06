using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace clientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient x = new TcpClient("localhost", 7777);
            Console.Read();
        }
    }
}
