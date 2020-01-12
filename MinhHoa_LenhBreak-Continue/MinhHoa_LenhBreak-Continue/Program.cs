using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhHoa_LenhBreak_Continue
{
	class Program
	{
		static void Main(string[] args)
		{
			string signal = "0";
			while(signal!="X")
			{
				Console.Write("Nhap vao mot tin hieu: ");
				signal = Console.ReadLine();
				Console.WriteLine("Tin hieu nhan duoc: {0}", signal);
				if(signal=="T")
				{
					Console.WriteLine("Ngung xu ly! Thoat\n");
					break;
				}
				if(signal=="0")
				{
					Console.WriteLine("Tat ca dieu tot!\n");
					continue;
				}
				Console.WriteLine("-----------\n");
			}
			Console.ReadLine();
		}
	}
}
