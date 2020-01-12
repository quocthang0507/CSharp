using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhHoa_LenhDoWhile
{
	class Program
	{
		public static int Main(string[] args)
		{
			int i = 11;
			do
			{
				Console.WriteLine("i: {0}", i);
				i++;
			}
			while (i < 10);
			Console.ReadLine();
			return 0;
		}
	}
}
