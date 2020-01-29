using System;

namespace MinhHoa_Operator
{
	class Program
	{
		static void Main(string[] args)
		{
			PhanSo a = new PhanSo(5, 6);
			Console.WriteLine(a);
			PhanSo b = new PhanSo(4, 10);
			Console.WriteLine(b);
			PhanSo c = a + b;
			Console.WriteLine(c);
			Console.ReadKey();
		}
	}

	class PhanSo
	{
		private int x;
		private int y;

		public PhanSo(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public override string ToString()
		{
			return string.Format("x/y = {0}/{1}", x, y);
		}

		/// <summary>
		/// Greatest Common Divisor
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static int GCD(int a, int b)
		{
			return a % b != 0 ? GCD(b, a % b) : b;
		}

		/// <summary>
		/// Least Common Multiple
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static int LCM(int a, int b)
		{
			return a * b / GCD(a, b);
		}

		public static PhanSo RutGon(PhanSo a)
		{
			int lcm = LCM(a.x, a.y);
			return new PhanSo(lcm / a.x, lcm / a.y);
		}

		public static PhanSo operator +(PhanSo a, PhanSo b)
		{
			int lcm = LCM(a.y, b.y);
			PhanSo ketqua = new PhanSo(a.x * (lcm / a.y) + b.x * (lcm / b.y), lcm);
			return PhanSo.RutGon(ketqua);
		}
	}
}
