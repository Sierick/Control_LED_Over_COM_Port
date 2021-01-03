using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace Serial
{
    class Ardunio
    {
        static SerialPort port;
        static void Main(string[] args)
        {
            int baud;
            string name;
            name = "COM6";
            baud = 9600;
            port = new SerialPort(name, baud);
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            port.Open();
            for (; ; )
            {
                string message;
                Console.Write("C#: ");
                message = Console.ReadLine();
                port.WriteLine(message);
                System.Threading.Thread.Sleep(500);
            }
        }

        static void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            for (int i = 0; i < (10000 * port.BytesToRead) / port.BaudRate; i++)
                ;
            Console.WriteLine("COM6: " + port.ReadExisting());
        }
    }
}