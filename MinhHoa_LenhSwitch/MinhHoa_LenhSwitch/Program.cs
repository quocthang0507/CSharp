using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhHoa_LenhSwitch
{
	class Program
	{
		static void Main(string[] args)
		{
			const int mauDo = 0;
			const int mauCam = 1;
			const int mauVang = 2;
			const int mauLuc = 3;
			const int mauLam = 4;
			const int mauCham = 5;
			const int mauTim = 6;
			int chonMau = mauLuc;
			switch(chonMau)
			{
				case mauDo:
					Console.WriteLine("Ban chon mau do");
					break;
				case mauCam:
					Console.WriteLine("Ban chon mau cam");
					break;
				case mauVang:
					Console.WriteLine("Ban chon mau vang");
					break;
				case mauLuc:
					Console.WriteLine("Ban chon mau luc");
					break;
				case mauLam:
					Console.WriteLine("Ban chon mau lam");
					break;
				case mauCham:
					Console.WriteLine("Ban chon mau cham");
					break;
				case mauTim:
					Console.WriteLine("Ban chon mau tim");
					break;
				default:
					Console.WriteLine("Ban khong chon mau nao het");
					break;
			}
			Console.WriteLine("Xin cam on!");
			Console.ReadLine();
		}
	}
}
