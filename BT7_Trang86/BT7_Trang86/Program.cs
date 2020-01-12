using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT7_Trang86
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Nhap vao mot ky tu : ");
			//ReadLine() = String, Read = int, Parse(Console.ReadLine()) = int
			int so = Console.Read();
			Console.WriteLine("Ki tu sau khi chuyen doi {0}", so);
			Console.ReadLine();
			Console.ReadLine();
		}
	}
}
