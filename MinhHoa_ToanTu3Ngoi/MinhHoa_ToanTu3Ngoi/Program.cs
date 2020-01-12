using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhHoa_ToanTu3Ngoi
{
	class Program
	{
		static void Main(string[] args)
		{
			int value1, value2, max, min;
			value1 = 10;
			value2 = 20;
			max = value1 > value2 ? value1 : value2;
			Console.WriteLine("Gia tri dau tien {0}, gia tri thu hai {1}", value1, value2);
			Console.WriteLine("Gia tri lon nhat: {0}", max);
			Console.ReadLine();
		}
	}
}
