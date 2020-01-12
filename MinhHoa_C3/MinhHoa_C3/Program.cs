using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhHoa_C3
{
	class Program
	{
		static void Main(string[] args)
		{
			//Minh hoa bien
			int bien1 = 9;
			Console.WriteLine("Sau khi khoi tao: bien1 = {0}", bien1);
			bien1 = 15;
			Console.WriteLine("Sau khi gan: bien1 = {0}", bien1);
			Console.ReadLine();
			//Minh hoa hang
			const int doSoi = 100;//Do C
			const int doDong = 0;//Do C
			Console.WriteLine("Do dong cua nuoc {0}", doDong);
			Console.WriteLine("Do soi cua nuoc {0}", doSoi);
			Console.ReadLine();
		}
	}
}
