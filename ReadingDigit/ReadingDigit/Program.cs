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
			Console.WriteLine(soTiengViet.DocTienBangChu(20202, ""));
			Console.ReadKey();
		}
	}
}
