/**
 *Author: Sinan Alkaya 
 *Date: dec 6th 2018
 *Changes:  
 */
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
            while (true)
            {
                Console.WriteLine("Send message: ");
                string message = Console.ReadLine();

                byte[] buffer = Encoding.UTF8.GetBytes(message);
                NetworkStream networkStream = x.GetStream();
                networkStream.Write(buffer, 0, buffer.Length);
                Console.ReadLine();

            }

        }
    }
}
