using System;

namespace MinhHoa_Lambda
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(Gcd(10, 20));
			Console.ReadKey();
		}

		static int Gcd(int a, int b) => a % b == 0 ? b : Gcd(b, a % b);
	}
}
