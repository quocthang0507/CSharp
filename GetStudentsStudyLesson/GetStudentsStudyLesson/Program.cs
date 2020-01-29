using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetStudentsStudyLesson
{
	class Program
	{
		static string url = @"http://online.dlu.edu.vn/Home/DrawingStudentSchedule?StudentId={0}&YearId=2019-2020&TermId=HK02&WeekId=3";
		static string id = "CT3301D";

		static void Main(string[] args)
		{
			//Console.Write("Username: ");
			//string username = Console.ReadLine();
			//Console.Write("Password: ");
			//string password = Console.ReadLine();
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			HasRegistered("1610207", "0_matkhauonlinecuaLQTh@ng", id);
			Console.ReadKey();
		}

		static string ProcessString(string str)
		{
			return str.Substring(0, 7);
		}

		static void HasRegistered(string username, string password, string id)
		{
			using (var client = new CookieAwareWebClient())
			{
				var values = new NameValueCollection { { "txtTaiKhoan", username }, { "txtMatKhau", password } };
				client.Encoding = Encoding.UTF8;
				try
				{
					client.UploadValues(new Uri(@"http://online.dlu.edu.vn/Login"), "POST", values);
				}
				catch (Exception)
				{
					Console.WriteLine("Loi ket noi mang");
					return;
				}
				StreamReader reader = new StreamReader(@"..\..\Data.txt");
				string mssv;
				while ((mssv = reader.ReadLine()) != null)
				{
					var html = client.DownloadString(string.Format(url, ProcessString(mssv)));
					if (html.Contains("<title>Đăng nhập</title>"))
					{
						Console.WriteLine("Loi dang nhap");
						return;
					}
					else if (html.Contains(id))
					{
						Console.WriteLine(mssv);
					}
				}
				Console.WriteLine("End");
			}
		}
	}
}

