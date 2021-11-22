using HtmlAgilityPack;
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
		static string url = @"http://online.dlu.edu.vn/Home/DrawingStudentSchedule?StudentId={0}&YearId=2021-2022&TermId=HK01&WeekId=48";
		static string id = "20CT1102";

		static void Main(string[] args)
		{
			Console.Write("Username: ");
			string username = Console.ReadLine();
			Console.Write("Password: ");
			string password = Console.ReadLine();
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			HasRegistered(username, password, id);
			Console.ReadKey();
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
					var html = client.DownloadString(string.Format(url, mssv));
					if (html.Contains("<title>Đăng nhập</title>"))
					{
						Console.WriteLine("Loi dang nhap");
						return;
					}
					else
					{
						HtmlDocument document = new HtmlDocument();
						document.LoadHtml(html);
						var tables = document.DocumentNode.SelectSingleNode("//table");
						bool flag = false;
						foreach (var row in tables.SelectNodes("//tr"))
						{
							foreach (var cell in row.SelectNodes("//td"))
							{
								var htmlCell = cell.InnerHtml;
								if (!flag && htmlCell.Contains(id))
								{
									if (htmlCell.Contains("CTK45B - nhom 2"))
									{
										Console.WriteLine(mssv + '\t' + 2);
										flag = true;
									}
									else if (htmlCell.Contains("CTK45B - nhom 1"))
									{
										Console.WriteLine(mssv + '\t' + 1);
										flag = true;
									}
									else
										Console.WriteLine(mssv);
								}
							}
						}
					}
				}
				Console.WriteLine("End");
			}
		}
	}
}

