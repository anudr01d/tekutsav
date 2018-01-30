using System.Collections.Generic;
using TEKUtsav.Models;
using TEKUtsav.Models.Entities;

namespace TEKUtsav.Models
{
    public class MaterialMeasurement : TableData
    {
        public string WorkflowId { get; set; }

        public string MaterialId { get; set; }

        public string MeasurementUnitId { get; set; }

		public string MeasurementUnitTag { get; set; }

		public string InsideStart { get; set; }

		public string OutsideStart { get; set; }

        public string InsideFinish { get; set; }

		public string OutsideFinish { get; set; }

		public string TruckTemperature { get; set; }

		public string SampleTemperature { get; set; }

		public string TruckScale { get; set; }

		public string DigitalScale { get; set; }

        public string SAPWeightReceipt { get; set; }

		public string Difference { get; set; }

        public string TankNumber { get; set; }

        public string SealNumber { get; set; }

        public string SAPMIGONumber { get; set; }

		public List<MaterialMeasurementComment> MaterialMeasurementComments { get; set; }
    }
}
