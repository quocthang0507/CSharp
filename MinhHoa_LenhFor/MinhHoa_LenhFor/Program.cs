using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhHoa_LenhFor
{
	class Program
	{
		static void Main(string[] args)
		{
			for(int i=0;i<30;i++)
			{
				if (i % 10 == 0)
					Console.WriteLine("{0} ", i);
				else
					Console.Write("{0} ", i);
			}
			Console.ReadLine();
		}
	}
}
