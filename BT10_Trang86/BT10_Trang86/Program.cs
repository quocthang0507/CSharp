using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT10_Trang86
{
	class Program
	{
		static void Main(string[] args)
		{
			int hinh = 0;
			//double c, s;
		lap:
			{
				while (hinh != 1 && hinh != 2 && hinh != 3 && hinh != 4)
				{
					Console.Write("Chon 1 trong 4 hinh sau (1 = Hinh tron, 2 = Hinh chu nhat, 3 = Hinh thang, 4 = Hinh tam giac) : ");
					hinh = int.Parse(Console.ReadLine());
				}
				if (hinh == 1) //Hinh tron
					HinhTron();
				if (hinh == 2) //Hinh chu nhat
					HinhChuNhat();
				if (hinh == 3) //Hinh thang
					HinhThang();
				if (hinh == 4) //Hinh tam giac
					HinhTamGiac();
			}
			int thoat;
			Console.Write("Ban co muon tiep tuc khong? (0 = Thoat, 1 = Dong y) : ");
			thoat = int.Parse(Console.ReadLine());
			if (thoat == 1)
			{
				Console.WriteLine();
				hinh = 0;
				goto lap;
			}
			Console.ReadLine();
		}
		static void HinhTron()
		{
			double radius;
			Console.Write("Nhap ban kinh hinh tron : ");
			radius = double.Parse(Console.ReadLine());
			Console.WriteLine("Chu vi hinh tron {0},\nDien tich hinh tron {1}", 2 * Math.PI * radius, Math.PI * Math.Pow(radius, 2));
		}
		static void HinhChuNhat()
		{
			double dai = 0, rong = 1;
			while (dai < rong)
			{
				Console.Write("Nhap chieu dai HCN : ");
				dai = double.Parse(Console.ReadLine());
				Console.Write("Nhap chieu rong HCN : ");
				rong = double.Parse(Console.ReadLine());
			}
			Console.WriteLine("Chu vi HCN {0},\nDien tich HCN {1}", (dai + rong) * 2, dai * rong);
		}
		static void HinhThang()
		{
			double a, b, c, d, h;
			Console.Write("Nhap vao do dai day tren : ");
			a = double.Parse(Console.ReadLine());
			Console.Write("Nhap vao do dai day duoi : ");
			b = double.Parse(Console.ReadLine());
			Console.Write("Nhap vao do dai canh ben trai : ");
			c = double.Parse(Console.ReadLine());
			Console.Write("Nhap vao do dai canh ben phai : ");
			d = double.Parse(Console.ReadLine());
			Console.Write("Nhap vao do dai chieu cao : ");
			h = double.Parse(Console.ReadLine());
			Console.WriteLine("Chu vi hinh thang {0},\nDien tich hinh thang {1}", a + b + c + d, (a + b) / 2 * h);
		}
		static void HinhTamGiac()
		{
			double a = 1, b = 2, c = 3, h;
			while (a + b <= c || a + c <= b || b + c <= a)
			{
				Console.Write("Nhap vao do dai canh dau tien : ");
				a = double.Parse(Console.ReadLine());
				Console.Write("Nhap vao do dai canh thu hai : ");
				b = double.Parse(Console.ReadLine());
				Console.Write("Nhap vao do dai canh day : ");
				c = double.Parse(Console.ReadLine());
			}
			Console.Write("Nhap vao do dai chieu cao tuong ung canh day : ");
			h = double.Parse(Console.ReadLine());
			Console.WriteLine("Chu vi tam giac {0},\nDien tich tam giac {1}", a + b + c, c * h / 2);
		}
	}
}
