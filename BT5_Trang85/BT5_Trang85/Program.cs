using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT5_Trang85
{
	class Program
	{
		static void Main(string[] args)
		{
			for (int i = 1; i <= 6; i++, Console.WriteLine())
				for (int j = 1; j <= i; j++)
					Console.Write("* ");
			Console.WriteLine();
			for (int i = 6; i >= 1; i--, Console.WriteLine())
				for (int j = 1; j <= i; j++)
					Console.Write("$ ");
			Console.WriteLine();
			for (int i = 1; i <= 6; i++, Console.WriteLine())
			{
				for (int t = 10 - (i - 1) * 2; t >= 1; t--)
					Console.Write(" ");
				for (int j = 1; j <= i + i - 1; j++)
					Console.Write("* ");
				for (int t = 10 - (i - 1) * 2; t >= 1; t--)
					Console.Write(" ");
			}
			Console.ReadLine();
		}
	}
}