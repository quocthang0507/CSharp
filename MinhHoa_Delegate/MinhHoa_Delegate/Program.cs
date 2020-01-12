using System;

namespace MinhHoa_Delegate
{
    class Program
    {
        delegate int TwoInt(int x, int y);

        static void Main(string[] args)
        {
            TwoInt sum = new TwoInt(MathUtils.Plus);
            Console.WriteLine(sum(10, 20));
            Console.ReadKey();
        }
    }

    class MathUtils
    {
        public static int Plus(int x, int y) => x + y;

        public static int Minus(int x, int y) => x - y;

        public static int Divide(int x, int y) => x / y;

        public static int Multiple(int x, int y) => x * y;
    }
}
