using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TEKUtsav.Models;

namespace TEKUtsav.Ral.Measurements
{
	public interface IMeasurementsRestApi
	{
		Task<MaterialMeasurement> VerifyMeasurements(MaterialMeasurement workFlowItem);
		Task<MaterialMeasurement> RejectContainer(MaterialMeasurement workFlowItem);
	}
}
