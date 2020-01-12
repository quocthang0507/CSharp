using System;
public class ThoiGian
{
	public void ThoiGianHienHanh()
	{
		Console.WriteLine("Thoi gian hien hanh la : {0}/{1}/{2} {3}:{4}:{5}", Ngay, Thang, Nam, Gio, Phut, Giay);
		Console.ReadLine();
	}
	//Ham khoi dung
	public ThoiGian(System.DateTime dt)
	{
		Nam=dt.Year;
		Thang=dt.Month;
		Ngay = dt.Day;
		Gio = dt.Hour;
		Phut = dt.Minute;
		Giay = dt.Second;
	}
	//Bien thanh vien private
	int Nam;
	int Thang;
	int Ngay;
	int Gio;
	int Phut;
	int Giay;
}
public class Tester
{
	static void Main()
	{
		System.DateTime currentTime = System.DateTime.Now;
		ThoiGian t = new ThoiGian(currentTime);
		t.ThoiGianHienHanh();
	}
}