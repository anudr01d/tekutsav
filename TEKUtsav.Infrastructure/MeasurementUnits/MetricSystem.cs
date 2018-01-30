using System;
using TEKUtsav.Infrastructure.Constants;

namespace TEKUtsav.Infrastructure
{
	public class MetricSystems : Unit
	{
		public MetricSystems()
		{
		}

		public override string LengthMajorUnit
		{
			get
			{
				return Globals.METER;
			}
		}


		public override string LengthMinorUnit
		{
			get
			{
				return Globals.CENTIMETER;
			}
		}

		public override string TemperatureUnit
		{
			get
			{
				return Globals.CELCIUS;
			}
			set
			{
				base.WeightUnit = value;
			}
		}

		public override string WeightUnit
		{
			get
			{
				return Globals.KILOGRAM;
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
				return 2;
			}
			set
			{
				base.MeasurementUnitId = value;
			}
		}
	}
}
