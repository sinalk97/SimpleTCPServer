/*
 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTCPServer
{
    class main
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Controller x = new Controller();
                x.run();
            }
            else
            {
                Console.WriteLine("this software does not take console arguments");
            }
        }
    }
}
