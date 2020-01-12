using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT8_Trang86
{
	class Program
	{
		static void Main(string[] args)
		{
			double a, b, c;
			int pt = 0;
		lap:
			{
				while (pt != 1 && pt != 2)
				{
					Console.Write("Ban muon goi chuc nang nao? (1 = Phuong trinh bac nhat, 2 = Phuong trinh bac hai) : ");
					pt = int.Parse(Console.ReadLine());
				}
				if (pt == 1)
				{
					Console.Write("Nhap gia tri a = ");
					a = double.Parse(Console.ReadLine());
					Console.Write("Nhap gia tri b = ");
					b = double.Parse(Console.ReadLine());
					PT_BacNhat(a, b);
				}
				else
				{
					Console.Write("Nhap gia tri a = ");
					a = double.Parse(Console.ReadLine());
					Console.Write("Nhap gia tri b = ");
					b = double.Parse(Console.ReadLine());
					Console.Write("Nhap gia tri c = ");
					c = double.Parse(Console.ReadLine());
					PT_BacHai(a, b, c);
				}
			}
			Console.Write("Ban co muon thuc hien tiep khong? (0 = Khong, 1 = Dong y) : ");
			int thoat = int.Parse(Console.ReadLine());
			if (thoat == 1)
			{
				Console.WriteLine();
				pt = 0;
				goto lap;
			}
			Console.ReadLine();
		}
		static void PT_BacNhat(double a, double b)
		{
			if (a == 0)
				Console.WriteLine("Phuong trinh vo nghiem");
			else
				Console.WriteLine("Phuong trinh co nghiem {0}", -b / a);
		}
		static void PT_BacHai(double a, double b, double c)
		{
			double delta;
			delta = b * b - 4 * a * c;
			if (a == 0)
				PT_BacNhat(b, c);
			else if (a!=0)
			{
				if (delta < 0)
					Console.WriteLine("Phuong trinh vo nghiem");
				if (delta == 0)
					Console.WriteLine("Phuong trinh co nghiem kep x = {0}", -b / (2 * a));
				if (delta > 0)
				{
					Console.WriteLine("Phuong trinh co 2 nghiem phan biet");
					Console.WriteLine("x1= {0}, \nx2={1}", (-b + Math.Sqrt(delta)) / (2 * a), (-b - Math.Sqrt(delta)) / (2 * a));
				}
			}
		}
	}
}