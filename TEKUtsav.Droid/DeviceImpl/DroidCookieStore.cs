using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using Android.Webkit;
using TEKUtsav.Infrastructure.CookieStorage;

namespace TEKUtsav.Droid
{
public class DroidCookieStore : IPlatformCookieStore
	{
		private readonly string _url;
		private readonly object _refreshLock = new object();

		public IEnumerable<Cookie> CurrentCookies
		{
			get { return RefreshCookies(); }
		}

		public DroidCookieStore(string url = "")
		{
			if (string.IsNullOrWhiteSpace(url))
			{
				throw new ArgumentNullException("url", "On Android, 'url' cannot be empty, please provide a base URL for it to use when loading related cookies");
			}
			_url = url;
		}

		private IEnumerable<Cookie> RefreshCookies()
		{
			lock (_refreshLock)
			{
				// .GetCookie returns ALL cookies related to the URL as a single, long 
				// string which we have to split and parse
				var allCookiesForUrl = CookieManager.Instance.GetCookie(_url);

				if (string.IsNullOrWhiteSpace(allCookiesForUrl))
				{
					Debug.WriteLine(string.Format("No cookies found for '{0}'. Exiting.", _url));
					yield return new Cookie("none", "none");
				}
				else
				{
					Debug.WriteLine(string.Format("\r\n===== CookieHeader : '{0}'\r\n", allCookiesForUrl));

					var cookiePairs = allCookiesForUrl.Split(' ');
					foreach (var cookiePair in cookiePairs.Where(cp => cp.Contains("=")))
					{
						// yeah, I know, but this is a quick-and-dirty, remember? ;)
						var cookiePieces = cookiePair.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
						if (cookiePieces.Length >= 2)
						{
							cookiePieces[0] = cookiePieces[0].Contains(":")
								? cookiePieces[0].Substring(0, cookiePieces[0].IndexOf(":"))
								: cookiePieces[0];

							// strip off trailing ';' if it's there (some implementations on droid have it, some do not)
							cookiePieces[1] = cookiePieces[1].EndsWith(";")
								? cookiePieces[1].Substring(0, cookiePieces[1].Length - 1)
								: cookiePieces[1];

							yield return new Cookie()
							{
								Name = cookiePieces[0],
								Value = cookiePieces[1],
								Path = "/",
								Domain = new Uri(_url).DnsSafeHost,
							};
						}

					}
				}
			}
		}

		public void DumpAllCookiesToLog()
		{
			if (CurrentCookies.All(c => c.Name == "none"))
			{
				Debug.WriteLine("No cookies in your Android cookie store. Srsly? No cookies? At all?!?");
			}
			CurrentCookies.Where(c => c.Name != "none").ToList().ForEach(cookie => Debug.WriteLine(string.Format("Cookie dump: {0} = {1}", cookie.Name, cookie.Value)));
		}


		public void DeleteAllCookiesForSite(string url)
		{
			// TODO remove cookies only for a specific site, coz this is a bit scorched-earth...
			CookieManager.Instance.RemoveAllCookie();
		}
	}
}
