using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT2_Trang35
{
	class Program
	{
		public static void Main()
		{
			int radius = 4; //Bien so nguyen
			const double PI = 3.14159; //Hang so thuc
			double circum, area; //Bien so thuc
			area = PI * radius * radius; //radius la ban kinh
			circum = 2 * PI * radius;
			//In ket qua
			Console.WriteLine("Ban kinh = {0}, PI= {1}", radius, PI);
			Console.WriteLine("Dien tich {0}", area);
			Console.WriteLine("Chu vi {0}", circum);
			Console.ReadLine(); //Dung chuong trinh de nguoi dung doc ket qua
		}
	}
}
