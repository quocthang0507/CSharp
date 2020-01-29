using System;

namespace MinhHoa_PhuongThucHuy
{
	class Program
	{
		static void Main(string[] args)
		{
			Execute();
			GC.Collect(); //Ép hệ thống thu hồi bộ nhớ (thực tế không cần ép, nó sẽ tự chạy khi cần)
			Console.ReadKey();
		}

		private static void Execute()
		{
			Product product = new Product("ABC");
			product = null; //đối tượng tạo không còn biến nào tham chiếu đến
		}
	}

	class Product
	{
		private string ProductName;

		public Product(string productName)
		{
			ProductName = productName;
			Console.WriteLine("Created an object");
		}

		~Product()
		{
			Console.WriteLine("Canceled an object");
		}
	}
}
