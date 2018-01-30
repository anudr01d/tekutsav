using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TEKUtsav.Infrastructure;

namespace TEKUtsav.Models.Entities
{
	public class MultiSelectionItem
	{
		public String Name { get; set; }
		public MeasurementUnits Unit { get; set;}
    }
}
