using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;

namespace ScanAvatar
{
	class Program
	{
		static void Main(string[] args)
		{
			ScanAvatar avatar = new ScanAvatar(@"C:\Users\quoct\Documents\Visual Studio 2019\ScanAvatar\ScanAvatar\Students.txt");
			avatar.SaveAllImagesFromFile();
			Console.ReadKey();
		}
	}

	class ScanAvatar
	{
		string remoteUri = @"http://online.dlu.edu.vn/HinhSV/";
		string fileName = "{0}.jpg";
		string folder = @"Hinh KT XS\";
		WebClient webClient;

		string pathToFile;

		public ScanAvatar(string pathToFile)
		{
			this.pathToFile = pathToFile;
			webClient = new WebClient();
		}

		/// <summary>
		/// Read student IDs from file
		/// </summary>
		/// <param name="pathToFile">Path to file .txt</param>
		/// <returns>List of student IDs</returns>
		private List<string> ReadFromFile(string pathToFile)
		{
			List<string> data = new List<string>();
			using (StreamReader reader = new StreamReader(pathToFile))
			{
				while (!reader.EndOfStream)
				{
					data.Add(reader.ReadLine());
				}
				reader.Close();
			}
			return data;
		}

		/// <summary>
		/// Get image url from ID
		/// </summary>
		/// <param name="id">Student ID</param>
		/// <returns>Image Url</returns>
		private string GetLink(string id)
		{
			return string.Format(remoteUri + fileName, id);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		private string GetFileName(string id)
		{
			return string.Format(folder + fileName, id);
		}

		/// <summary>
		/// Check Image URL
		/// </summary>
		/// <param name="url">Your URL</param>
		/// <returns></returns>
		private bool IsImageUrl(string url)
		{
			var request = (HttpWebRequest)HttpWebRequest.Create(url);
			request.Method = "HEAD";
			try
			{
				using var response = request.GetResponse();
				return response.ContentType.ToLower(CultureInfo.InvariantCulture).StartsWith("image/");
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool SaveStudentImage(string id)
		{
			try
			{
				webClient.DownloadFile(GetLink(id), GetFileName(id));
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		public void SaveAllImagesFromFile()
		{
			List<string> data = ReadFromFile(pathToFile);
			Directory.CreateDirectory(folder);
			foreach (var item in data)
			{
				if (IsImageUrl(GetLink(item)))
					if (SaveStudentImage(item))
						Console.WriteLine(item + " successfully downloaded file");
					else
						Console.WriteLine(item + " unsuccessfully download file");
				else
					Console.WriteLine(item + " unsuccessfully download file");
			}
			Console.WriteLine("End of file!");
		}
	}
}
