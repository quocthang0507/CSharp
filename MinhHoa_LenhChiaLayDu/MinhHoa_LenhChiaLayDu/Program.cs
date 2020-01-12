using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhHoa_LenhChiaLayDu
{
	class Program
	{
		static void Main(string[] args)
		{
			int i1, i2;
			float f1, f2;
			double d1, d2;
			decimal dec1, dec2;
			i1 = 17;
			i2 = 4;
			f1 = 17f;
			f2 = 4f;
			d1 = 17;
			d2 = 4;
			dec1 = 17;
			dec2 = 4;
			Console.WriteLine("Integer: \t{0}", i1 / i2);
			Console.WriteLine("Float: \t{0}", f1 / f2);
			Console.WriteLine("Double: \t{0}", d1 / d2);
			Console.WriteLine("Decimal: \t{0}", dec1 / dec2);
			Console.WriteLine("\nModulus: \t{0}", i1 % i2);
			Console.ReadLine();
		}
	}
}
