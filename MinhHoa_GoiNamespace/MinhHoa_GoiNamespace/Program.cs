using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
	namespace Demo1
	{
		class Example1
		{
			public static void Show1()
			{
				Console.WriteLine("Lop example 1");
			}
		}
	}
	namespace Demo2
	{
		public class Tester
		{
			public static int Main()
			{
				Demo1.Example1.Show1();
				Demo1.Example2.Show2();
				Console.ReadLine();
				return 0;
			}
		}
	}
}

namespace MyLib.Demo1
{
	class Example2
	{
		public static void Show2()
		{
			Console.WriteLine("Lop example 2");
		}
	}
}