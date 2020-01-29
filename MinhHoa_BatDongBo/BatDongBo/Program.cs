using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BatDongBo
{
	/// <summary>
	/// Có 3 thằng bé chơi với nhau trò chơi tính nhẩm:
	/// - Một đứa làm trọng tài đếm giờ
	/// - Hai đứa còn lại tính nhẩm một biểu thức
	/// - Đứa nào tính ra trước thì thắng
	/// </summary>
	class Program
	{
		private static Random random;

		static void Main(string[] args)
		{
			random = new Random();

			// cho phép tính 10 + 10
			// thằng bé A bắt đầu tính              
			Run("A", SumAsync(10, 10));

			// thằng bé B bắt đầu tính 
			Run("B", SumAsync(10, 10));

			// thằng bé đếm thời gian
			for (int i = 0; i < 60; i++)
			{
				Thread.Sleep(50);
				Console.WriteLine(i);
			}

			Console.ReadKey();
		}

		/// <summary>
		/// Method chạy bất đồng bộ
		/// </summary>
		/// <param name="name"></param>
		/// <param name="task"></param>
		private static async void Run(string name, Task<int> task)
		{
			// chờ cho khi task thực hiện xong thì mới chạy các lệnh sau nó
			var result = await task;
			Console.WriteLine(name + " has got the answer = " + result);
		}

		private static Task<int> SumAsync(int a, int b)
		{
			return Task.Factory.StartNew(() => Sum(a, b));
		}

		private static int Sum(int a, int b)
		{
			var calculatingTime = random.Next(3000);
			Thread.Sleep(calculatingTime);

			return a + b;
		}
	}
}
