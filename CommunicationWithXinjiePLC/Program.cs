using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BingLibrary.hjb.PLC;

namespace CommunicationWithXinjiePLC
{
    class Program
    {
        
        static void Main(string[] args)
        {
            bool IsPLCConnect = false;
            ushort i = 0;
            ThingetPLC Xinjie;
            Xinjie = new ThingetPLC();
            while (true)
            {
                i++;
                System.Threading.Thread.Sleep(10);
                IsPLCConnect = Xinjie.ReadSM(0);
                //Console.WriteLine(IsPLCConnect.ToString());
                //IsPLCConnect = Xinjie.ReadM(24576);
                if (IsPLCConnect)
                {
                    Xinjie.WriteW(2, "58");
                    double a = Xinjie.ReadW(2);
                    Console.WriteLine(a.ToString());
                }
                else
                {
                    System.Threading.Thread.Sleep(1000);
                    Xinjie.ModbusDisConnect();
                    Xinjie.ModbusInit("COM3", 19200, System.IO.Ports.Parity.Even, 8, System.IO.Ports.StopBits.One);
                    Xinjie.ModbusConnect();
                }
                if (i > 9)
                {
                    i = 0;
                    Console.ReadKey();
                }
            }
            


        }
    }
}
