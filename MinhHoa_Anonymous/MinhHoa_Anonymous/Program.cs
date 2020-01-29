using System;

namespace MinhHoa_Anonymous
{
	class Program
	{
		/// <summary>
		/// Kiểu vô danh (Anonymous Type) - là kiểu không có tên
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			var anonymous = new
			{
				id = "1610207",
				name = "Thang",
				@class = "CTK40"
			};
			Console.WriteLine(anonymous);
			Console.ReadKey();
		}
	}
}
