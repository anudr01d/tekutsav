using System;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using Foundation;
using TEKUtsav.Infrastructure;
using TEKUtsav.Infrastructure.CookieStorage;

namespace TEKUtsav.iOS
{

	public class IOSCookieStore : IPlatformCookieStore
	{
		private readonly object _refreshLock = new object();

		public IEnumerable<Cookie> CurrentCookies
		{
			get { return RefreshCookies(); }
		}

		public IOSCookieStore(string url = "")
		{
		}

		private IEnumerable<Cookie> RefreshCookies()
		{
			lock (_refreshLock)
			{
				foreach (var cookie in NSHttpCookieStorage.SharedStorage.Cookies)
				{
					yield return new Cookie
					{
						Comment = cookie.Comment,
						Domain = cookie.Domain,
						HttpOnly = cookie.IsHttpOnly,
						Name = cookie.Name,
						Path = cookie.Path,
						Secure = cookie.IsSecure,
						Value = cookie.Value,
						// TODO expires? / expired?
						Version = Convert.ToInt32(cookie.Version)
					};
				}
			}
		}

		public void DumpAllCookiesToLog()
		{
			if (!CurrentCookies.Any())
			{
				Debug.WriteLine("No cookies in your iOS cookie store. Srsly? No cookies? At all?!?");
			}
			CurrentCookies.ToList().ForEach(cookie => Debug.WriteLine(string.Format("Cookie dump: {0} = {1}", cookie.Name, cookie.Value)));
		}

		public void DeleteAllCookiesForSite(string url)
		{
			var cookieStorage = NSHttpCookieStorage.SharedStorage;
			//foreach (var cookie in cookieStorage.CookiesForUrl(new NSUrl(url)).ToList())
			//{
			//	cookieStorage.DeleteCookie(cookie);
			//}

			foreach (var cookie in cookieStorage.Cookies)
			{
				cookieStorage.DeleteCookie(cookie);
			}

			// you MUST call the .Sync method or those cookies may hang around for a bit
			NSUserDefaults.StandardUserDefaults.Synchronize();
		}

	}
}
