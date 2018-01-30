using System;
namespace TEKUtsav.Models
{
	public class AppUnit
	{
		public String MenuImageSource
		{
			get
			{
				switch (this.Name)
				{
					case "TEKUtsavScan":
						return "TEKUtsavscan";
					default:
						return string.Empty;
				}
			}
		}
		public String Name { get; set; }
	}
}
