using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT6_Trang85
{
	class Program
	{
		static void Main(string[] args)
		{
			int i, j, k, t;
			int[] Day = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
			for (i = 1; i <= 10; i++, Console.WriteLine()) //Hang
			{
				//So nua ben trai
				for (j = i - 1, t = 1; j < 10 && t <= i; j++, t++)
					Console.Write("{0} ", Day[j]);
				if (Day[j - 1] == 0)
					for (j = 0; j < 10 && t <= i; j++, t++)
						Console.Write("{0} ", Day[j]);
				//So nua ben phai
				if (i > 1 && Day[j - 1] == 1)
					for (j = 9; j >= 0 && t <= i + i - 1; j--, t++)
						Console.Write("{0} ", Day[j]);
				for (k = j - 2; k >= 0 && t <= i + i - 1; k--, t++)
					Console.Write("{0} ", Day[k]);
			}
			Console.ReadLine();
		}
	}
}