using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhHoa_GoiHam
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Ham Main chuan bi goi ham Func() ...");
			Func();
			Console.WriteLine("Tro lai ham Main()");
			Console.ReadLine();
		}
		static void Func()
		{
			Console.WriteLine("---Day lam ham Func()---");
		}
	}
}
