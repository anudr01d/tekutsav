using System;
using Xamarin.Forms;

namespace TEKUtsav.Infrastructure
{
	public class HAccountUtil
	{
		public HAccountUtil()
		{
		}

		public static string GetHAccount()
		{
			try
			{
				return Application.Current.Properties["username"] as string;
			}
			catch (Exception e)
			{
				return string.Empty;
			}

		}
	}
}
