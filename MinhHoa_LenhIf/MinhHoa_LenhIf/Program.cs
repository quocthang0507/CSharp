using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhHoa_LenhIf
{
	class Program
	{
		static void Main(string[] args)
		{
			int var1 = 10;
			int var2 = 20;
			if (var1 > var2)
				Console.WriteLine("var1: {0} > var2: {1}", var1, var2);
			else
				Console.WriteLine("var2: {0} > var1: {1}", var2, var1);
			var1 = 30;
			if(var1>var2)
			{
				var2 = var1++;
				Console.WriteLine("Gan gia tri var1 cho var2");
				Console.WriteLine("Tang bien var1 len mot");
				Console.WriteLine("var1 = {0}, var2 = {1}", var1, var2);
			}
			else
			{
				var1 = var2;
				Console.WriteLine("Thiet lap gia tri var1 = var2");
				Console.WriteLine("var1 = {0}, var2={1}", var1, var2);
			}
			Console.ReadLine();
		}
	}
}
