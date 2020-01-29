using System;

namespace MinhHoa_Dynamic
{
	/// <summary>
	/// Biến kiểu động - ngầm định - khai báo với từ khóa dynamic, 
	/// dynamic allows the type of value to change after it is assigned to initially
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			var bien = new
			{
				abc = 123,
				def = "ghi"
			};
			Execute(bien);
			Console.ReadKey();
		}

		static void Execute(dynamic dvar)
		{
			// ở thời điểm chạy mà đối tượng ở tham số có thuộc tính abc 
			// thì sẽ không lỗi, nếu không có thuộc tính abc sẽ sinh ngoại lệ
			Console.WriteLine(dvar.abc);
		}
	}
}
