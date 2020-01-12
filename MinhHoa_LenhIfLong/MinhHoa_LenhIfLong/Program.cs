using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhHoa_LenhIfLong
{
	class Program
	{
		static void Main(string[] args)
		{
			int tuoi;
			bool coGiaDinh;
			bool gioiTinh;
			tuoi = 24;
			coGiaDinh = false;
			gioiTinh = true;
			if (tuoi >= 19)
			{
				if (coGiaDinh == false)
				{
					if (gioiTinh == false)
						Console.WriteLine("Nu co the ket hon");
					else
						if (tuoi > 19)
							Console.WriteLine("Nam co the ket hon");
				}
				else
					Console.WriteLine("Khong the ket hon nua vi da ket hon");
			}
			else
				Console.WriteLine("Khong du tuoi ket hon");
			Console.ReadLine();
		}
	}
}
