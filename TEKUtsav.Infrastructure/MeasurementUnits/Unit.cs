using System;
namespace TEKUtsav.Infrastructure
{
	public class Unit
	{
		public virtual string LengthMajorUnit { get; set; }
		public virtual string LengthMinorUnit { get; set; }
		public virtual string TemperatureUnit { get; set; }
		public virtual string WeightUnit { get; set; }
		public virtual int MeasurementUnitId { get; set; }
	}
}
