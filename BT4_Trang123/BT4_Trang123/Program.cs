using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT4_Trang123
{
	class VD1
	{
		public string first;
	}
	class Program
	{
		static void Main(string[] args)
		{
			VD1 vd = new VD1();
			Console.Write("Nhap vao mot chuoi: ");
			vd.first = Console.ReadLine();
			Console.Write("Chuoi nhap vao : {0}", vd.first);
			Console.ReadLine();
		}
	}
}
