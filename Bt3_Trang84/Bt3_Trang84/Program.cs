using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bt3_Trang84
{
	class Program
	{
		static void Main(string[] args)
		{
			double myDouble;
			decimal myDecimal;
			myDouble = 3.14;
			myDecimal = 3.14M;
			//Phai them 'M' vao sau so thuc khi gan vao bien Decimal
			Console.WriteLine("My double : {0}", myDouble);
			Console.WriteLine("My decimal : {0}", myDecimal);
			Console.ReadLine();
		}
	}
}
