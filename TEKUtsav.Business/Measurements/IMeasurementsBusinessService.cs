using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TEKUtsav.Models;

namespace TEKUtsav.Business.Measurements
{
	public interface IMeasurementsBusinessService
	{
		Task<MaterialMeasurement> VerifyMeasurements(MaterialMeasurement workFlowItem);
		Task<MaterialMeasurement> RejectContainer(MaterialMeasurement workFlowItem);
	}
}
