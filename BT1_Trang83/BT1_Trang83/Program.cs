using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT1_Trang83
{
	class Program
	{
		static void Main(string[] args)
		{
			int x = 0;
			for(x=1;x<10;x++)
			{
				Console.Write("{0:03}", x);
			}
			Console.ReadLine();
		}
	}
}
