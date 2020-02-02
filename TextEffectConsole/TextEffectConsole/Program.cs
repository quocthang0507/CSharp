using System;

namespace TextEffectConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.CursorVisible = false;
			string[] str = new string[]
			{
				@" _             _____                    _____ _                       ",
				@"| |           |  _  |                  |_   _| |                      ",
				@"| |     __ _  | | | |_   _  ___   ___    | | | |__   __ _ _ __   __ _ ",
				@"| |    / _` | | | | | | | |/ _ \ / __|   | | | '_ \ / _` | '_ \ / _` |",
				@"| |___| (_| | \ \/' / |_| | (_) | (__    | | | | | | (_| | | | | (_| |",
				@"\_____/\__,_|  \_/\_\\__,_|\___/ \___|   \_/ |_| |_|\__,_|_| |_|\__, |",
				@"                                                                 __/ |",
				@"                                                                |___/ "
			};

			int n = str.Length;

			EText[] ET = new EText[n];
			int x, y;
			x = 15;
			y = 8;
			for (int i = 0; i < n; i++)
			{
				ET[i] = new EText(str[i], x, y + i);
			}

			while (true)
			{
				while (true)
				{
					foreach (EText et in ET)
					{
						et.ve();
					}
				}

			}
		}
	}

}
