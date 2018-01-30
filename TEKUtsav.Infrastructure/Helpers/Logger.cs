using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TEKUtsav.Infrastructure.Constants;

namespace TEKUtsav.Infrastructure
{
	public class Logger
	{
		public Logger()
		{
		}

		public static void WriteLog(string stack)
		{
			Debug.WriteLine(stack);
		}
	}
}
