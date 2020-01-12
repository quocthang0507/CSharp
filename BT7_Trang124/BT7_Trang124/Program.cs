using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT7_Trang124
{
	class PhuongTrinhBac2
	{
		public void KetQua()
		{
			if (x1 == x2)
				Console.WriteLine("Phuong trinh vo nghiem");
			else Console.WriteLine("Phuong trinh co nghiem la x1 = {0} va x2 = {1}", x1, x2);
		}
		public void TinhToan(double a, double b, double c)
		{
			if (a != 0)
			{
				delta = b * b - 4 * a * c;
				if (delta > 0)
				{
					x1 = (-b + Math.Sqrt(delta)) / (2 * a);
					x2 = (-b - Math.Sqrt(delta)) / (2 * a);
				}
				else if (delta == 0)
				{
					x1 = -b / (2 * a);
					x2 = x1;
				}
			}
			else x1 = -b / a;		
		}
		public double delta;
		public double x1;
		public double x2;
	}
	class Program
	{
		public static void Main(string[] args)
		{
			double a, b, c;
			Console.Write("Nhap a = ");
			a = double.Parse(Console.ReadLine());
			Console.Write("Nhap b = ");
			b = double.Parse(Console.ReadLine());
			Console.Write("Nhap c = ");
			c = double.Parse(Console.ReadLine());
			PhuongTrinhBac2 pt = new PhuongTrinhBac2();
			pt.TinhToan(a, b, c);
			pt.KetQua();
			Console.ReadLine();
		}
	}
}
