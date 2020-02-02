using System;

namespace TextEffectConsole
{
	class EText
	{
		int x, X, y, index, k, l;
		string s;
		ConsoleColor[] cl;
		ConsoleColor cl1, cl2;
		Random r;
		int iColor, nColor;
		public EText(string s, int x, int y)
		{
			this.x = x;
			this.y = y;
			X = x;
			k = 0;
			this.s = s;
			l = s.Length;
			index = l - 1;
			cl = new ConsoleColor[] { ConsoleColor.Magenta, ConsoleColor.Yellow, ConsoleColor.Red, ConsoleColor.White, ConsoleColor.Black, ConsoleColor.Green };
			nColor = cl.Length;
			cl1 = ConsoleColor.Black;
			cl2 = ConsoleColor.Green;
			r = new Random();
			iColor = 0;
		}
		public void ve()
		{

			Console.SetCursorPosition(X, y);
			for (int i = k; i < l; i++)
			{
				Console.ForegroundColor = cl1;
				if (i == index)
				{
					Console.ForegroundColor = cl2;
				}

				Console.Write(s[i]);

			}

			if (index == k)
			{
				k++;
				X++;
				index = l;
			}
			if (k == l - 1)
			{
				k = 0;
				X = x;
				cl1 = cl2;
				cl2 = cl[iColor];
				iColor++;
				if (iColor == nColor)
				{
					iColor = 0;
				}
			}
			index--;

		}

	}
}
