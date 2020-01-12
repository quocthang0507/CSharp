using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT1_Trang123
{
	public class HinhTron
	{
		public void HienThiKetQua()
		{
			Console.WriteLine("Hinh tron ban kinh {0}\nCo chu vi {1} va dien tich {2}", banKinh, chuVi, dienTich);
		}
		public void TinhToan(double r)
		{
			banKinh = r;
			chuVi = 2 * Math.PI * r;
			dienTich = Math.PI * Math.Pow(r, 2);
		}
		private double banKinh;
		private double chuVi;
		private double dienTich;
	}
	public class Program
	{
		static void Main(string[] args)
		{
			double banKinh;
			Console.Write("Nhap ban kinh cua hinh tron : ");
			banKinh = double.Parse(Console.ReadLine());
			HinhTron t = new HinhTron();
			t.TinhToan(banKinh);
			t.HienThiKetQua();
			Console.ReadLine();
		}
	}
}
