using System;
using System.Net;

namespace GetStudentsStudyLesson
{
	class CookieAwareWebClient : WebClient
	{
		private int? _timeout = null;
		public int? Timeout { get { return _timeout; } set { _timeout = value; } }
		public CookieContainer CookieContainer { get; private set; }
		public CookieCollection ResponseCookies { get; set; }
		public CookieAwareWebClient()
		{
			CookieContainer = new CookieContainer();
			this.ResponseCookies = new CookieCollection();
		}
		public CookieAwareWebClient(CookieContainer cookies) { this.CookieContainer = cookies; }
		public void SetTimeout(int timeout) { _timeout = timeout; }
		protected override WebRequest GetWebRequest(Uri address)
		{
			var request = (HttpWebRequest)base.GetWebRequest(address);
			request.CookieContainer = CookieContainer;
			if (_timeout.HasValue) { request.Timeout = _timeout.Value; }
			return request;
		}
	}
}
