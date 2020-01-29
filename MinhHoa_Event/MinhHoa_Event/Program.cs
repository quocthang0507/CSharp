using System;

namespace MinhHoa_Event
{
	class Program
	{
		static void Main(string[] args)
		{
			Publisher publisher = new Publisher();
			SubscriberA sa = new SubscriberA();
			SubscriberB sb = new SubscriberB();
			sa.Subscribe(publisher);
			sb.Subscribe(publisher);
			publisher.Send();
			Console.ReadKey();
		}
	}
	/// <summary>
	/// Lớp Publisher xây dựng một delegate có tên NotifyNews
	/// </summary>
	public class Publisher
	{
		public delegate void NotifyNews(object data);
		// public NotifyNews eventNews; // Delegate, chấp nhận phép gán =
		public event NotifyNews eventNews; //Event, chỉ chấp nhận += hoặc -=

		/// <summary>
		/// Khi Publisher thi hành Send() nó sẽ thi hành delegate này 
		/// và như vậy những đối tượng nào đăng ký vào delegate sẽ có 
		/// cơ hội nhận thông tin mới từ Publisher
		/// </summary>
		public void Send()
		{
			eventNews?.Invoke("New!!!");
		}
	}

	public class SubscriberA
	{
		public void Subscribe(Publisher publisher)
		{
			publisher.eventNews += ReceiverFromPulisher;
		}

		private void ReceiverFromPulisher(object data)
		{
			Console.WriteLine("SubscriberA: " + data.ToString());
		}
	}

	public class SubscriberB
	{
		public void Subscribe(Publisher publisher)
		{
			// Subscriber chỉ có thể đăng ký nhận sự kiện với toán tử += hoặc hủy nhận sự kiện với toán tử -= 
			publisher.eventNews += ReceiverFromPulisher;
		}

		private void ReceiverFromPulisher(object data)
		{
			Console.WriteLine("SubscriberB: " + data.ToString());
		}
	}
}
