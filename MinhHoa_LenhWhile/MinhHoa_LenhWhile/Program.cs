using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhHoa_LenhWhile
{
	class Program
	{
		public static int Main()
		{
			int i = 0;
			while (i < 10)
			{
				Console.WriteLine("i: {0} ", i);
				i++;
			}
			Console.ReadLine();
			return 0;
		}
	}
}
