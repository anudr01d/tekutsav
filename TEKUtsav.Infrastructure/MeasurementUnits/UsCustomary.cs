using System;
using TEKUtsav.Infrastructure.Constants;

namespace TEKUtsav.Infrastructure
{
	public class UsCustomary : Unit
	{
		public UsCustomary()
		{
		}

		public override string LengthMajorUnit
		{
			get
			{
				return Globals.FEET;
			}
		}


		public override string LengthMinorUnit
		{
			get
			{
				return Globals.INCHES;
			}
		}

		public override string TemperatureUnit
		{
			get
			{
				return Globals.FAHRENHEIT;
			}
			set
			{
				base.TemperatureUnit = value;
			}
		}

		public override string WeightUnit
		{
			get
			{
				return Globals.POUNDS;
			}
			set
			{
				base.WeightUnit = value;
			}
		}

		public override int MeasurementUnitId
		{
			get
			{
				return 1;
			}
			set
			{
				base.MeasurementUnitId = value;
			}
		}
	}
}
