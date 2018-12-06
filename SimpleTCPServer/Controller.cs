using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTCPServer
{
    public class Controller
    {
        private Connection _con;
        public Connection Con { get => _con; set => _con = value; }

        public Controller()
        {

        }

        public void run()
        {
            String port = "";
            Console.WriteLine("Port?");
            port = Console.ReadLine();
            try
            {
                this.Con = new Connection(Convert.ToInt32(port));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            this.serverStart();
        }

        public void serverStart()
        {
            this.Con.startServer();
        }
    }
}
