﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPClient
{
    class Program
    {
           static void Main(string[] args)
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var ipAdress = IPAddress.Parse("10.1.18.42");
            var port = 27001;

            var ep = new IPEndPoint(ipAdress, port);

            try
            {
                socket.Connect(ep);

                if (socket.Connected) {
                    Console.WriteLine("Connected to the Server . . . .");
                
                }
                else
                {
                    Console.WriteLine("Can not Connected to the Server");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can Not connect to the Server");
                Console.WriteLine(ex.Message);
            }

            while (true)
            {
                var msg = Console.ReadLine();
                var bytes = Encoding.UTF8.GetBytes(msg);
                socket.Send(bytes);
            }

           
        }
    }
}
