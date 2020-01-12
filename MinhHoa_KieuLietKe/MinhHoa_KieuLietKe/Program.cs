using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhHoa_KieuLietKe
{
	class Program
	{
		enum NhietDoNuoc
		{
			doDong = 0,
			doNguoi = 20,
			doAm = 40,
			doNong = 60,
			doSoi = 100,
		}
		static void Main()
		{
			Console.WriteLine("Nhiet do dong: {0}", NhietDoNuoc.doDong);
			Console.WriteLine("Nhiet do nguoi: {0}", NhietDoNuoc.doNguoi);
			Console.WriteLine("Nhiet do am: {0}", NhietDoNuoc.doAm);
			Console.WriteLine("Nhiet do nong: {0}", NhietDoNuoc.doNong);
			Console.WriteLine("Nhiet do soi: {0}", NhietDoNuoc.doSoi);
			Console.ReadLine();
		}
	}
}