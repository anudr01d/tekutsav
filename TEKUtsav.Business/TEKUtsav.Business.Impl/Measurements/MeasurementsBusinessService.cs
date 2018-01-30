//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TEKUtsav.Models;
//using TEKUtsav.Store.ContainerConditions;
//using TEKUtsav.Store.Measurements;

//namespace TEKUtsav.Business.Measurements.Impl
//{
//    public class MeasurementsBusinessService : IMeasurementsBusinessService
//    {
//		private readonly IMeasurementsStore _measurementsStore;
//		public MeasurementsBusinessService(IMeasurementsStore measurementsStore)
//		 {
//			if (measurementsStore == null) throw new ArgumentNullException("measurementsStore");
//			_measurementsStore = measurementsStore;
//         }

//		public async Task<MaterialMeasurement> VerifyMeasurements(MaterialMeasurement workFlowItem)
//		{
//			return await _measurementsStore.VerifyMeasurements(workFlowItem);
//		}

//		public async Task<MaterialMeasurement> RejectContainer(MaterialMeasurement workFlowItem)
//		{
//			return await _measurementsStore.RejectContainer(workFlowItem);
//		}
//	}
//}
