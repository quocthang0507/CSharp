using System;
using System.Collections.Generic;
using System.Linq;

namespace TimHangSoKapreka
{
	class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				run();
				print("Ban co muon tiep tuc khong? Nhan Esc de thoat");
				if (Console.ReadKey(true).Key == ConsoleKey.Escape)
					break;
				else println();
			}
		}

		static void run()
		{
			string input;
			print("Nhap mot so co 4 chu so co it nhat 2 chu so khac nhau: ");
			input = Console.ReadLine();
			if (checkValid(input))
				println("Tim duoc hang so Kapreka roi : " + findKapreka(input));
			else println("Ban nhap so khong dung");
		}

		private static int findKapreka(string input)
		{
			List<int> result = new List<int>();
			int curr = int.Parse(input);
			while (!result.Contains(curr))
			{
				result.Add(curr);
				int max = int.Parse(decString(input)),
					min = int.Parse(ascString(input));
				curr = max - min;
			}
			return curr;
		}

		static void print(string str = "")
		{
			Console.Write(str);
		}

		static void println(string str = "")
		{
			Console.WriteLine(str);
		}

		static bool checkValid(string number, int length = 4)
		{
			if (int.TryParse(number, out int x) && number.Length == length)
			{
				int max = 0;
				max = number.Count(c => c == number[0]);
				if (max == length)
					return false;
				else return true;
			}
			else return false;
		}

		static string ascString(string number)
		{
			return string.Concat(number.OrderBy(c => c));
		}

		static string decString(string number)
		{
			return string.Concat(number.OrderByDescending(c => c));
		}
	}
}
