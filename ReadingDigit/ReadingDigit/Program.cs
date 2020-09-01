using System;
using System.Text;

namespace ReadingDigit
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = Encoding.UTF8;
			DocSoTiengViet soTiengViet = new DocSoTiengViet();
			while (true)
			{
				Console.Write("Nhập một con số bất kỳ: ");
				if (int.TryParse(Console.ReadLine(), out int number))
				{
					Console.WriteLine(soTiengViet.DocTienBangChu(number, ""));
				}
				else break;
			}
			Console.ReadKey();
		}
	}
}
