using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEKUtsav.Models.Entities
{
	public class SingleSelectionItem
    {
		public string Type { get; set; }
        public String Name { get; set; }
		public bool IsSelected { get; set; }
		public String DisplayedName { get; set; }
    }
}
