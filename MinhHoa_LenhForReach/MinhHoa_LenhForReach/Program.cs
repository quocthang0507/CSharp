using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhHoa_LenhForReach
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] intArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			foreach (int item in intArray)
				Console.Write("{0} ", item);
			Console.ReadLine();
		}
	}
}
