/**
 *Author: Sinan Alkaya 
 *Date: dec 6th 2018
 *Changes:  
 * 26.05.2019: Added port setting
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
            Console.Write("Type in Port: ");
            string port = Console.ReadLine();
            Console.WriteLine("\n");
            Console.Write("type in Nickname:");
            string nickname = Console.ReadLine();
            Console.WriteLine("\n");
            
            int iport = 0;
            try
            {
                iport = Convert.ToInt32(port);
            }
            catch (Exception ex)
            {

                
            }

            TcpClient x = new TcpClient("localhost", iport);
            while (true)
            {
                Console.WriteLine("Send message: ");
                string message = nickname + ": "+ Console.ReadLine();

                byte[] buffer = Encoding.UTF8.GetBytes(message);
                NetworkStream networkStream = x.GetStream();
                networkStream.Write(buffer, 0, buffer.Length);
                //Console.ReadLine();

            }

        }
    }
}
