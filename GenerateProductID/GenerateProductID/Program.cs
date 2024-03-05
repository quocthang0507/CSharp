using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateProductID
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Machine ID: " + HardwareInfo.MachineId);
            Console.ReadKey();
        }
    }
}
