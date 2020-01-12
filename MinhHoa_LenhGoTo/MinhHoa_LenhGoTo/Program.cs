using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhHoa_LenhGoTo
{
	class Program
	{
		public static int Main()
		{
			int i = 0;
		lap: //Nhan 'lap'
			Console.WriteLine("i:{0}", i);
		i++;
		if (i < 10)
			goto lap; //Quay ve nhan 'lap'
		Console.ReadLine();
		return 0;
		}
	}
}
