using System;
using System.ComponentModel;
using TEKUtsav.Models.Entities;

namespace TEKUtsav.Models
{
	public class ContainerCondition : TableData, INotifyPropertyChanged
	{
		public string Description { get; set; }
		public string Order { get; set; }

		private bool _isYesSelected = false;
		public bool IsYesSelected
		{
			get
			{
				return this._isYesSelected;
			}
			set
			{
				if (this._isYesSelected != value)
				{
					this._isYesSelected = value;
					this.OnPropertyChanged("IsYesSelected");
				}
			}
		}

		private bool _isNoSelected = false;
		public bool IsNoSelected
		{
			get
			{
				return this._isNoSelected;
			}
			set
			{
				if (this._isNoSelected != value)
				{
					this._isNoSelected = value;
					this.OnPropertyChanged("IsNoSelected");
				}
			}
		}


		private string _rowStatus = string.Empty;
		public string RowStatus
		{
			get
			{
				return this._rowStatus;
			}
			set
			{
				if (this._rowStatus != value)
				{
					this._rowStatus = value;
					this.OnPropertyChanged("RowStatus");
				}
			}
		}


		private string _noDescription = string.Empty;
		public string NoDescription
		{
			get
			{
				return this._noDescription;
			}
			set
			{
				if (this._noDescription != value)
				{
                   	this._noDescription = value;
					this.OnPropertyChanged("NoDescription");
				}
			}
		}


		private string _floatingHint = "Description";
		public string FloatingHint
		{
			get
			{
				return this._floatingHint;
			}
			set
			{
				if (this._floatingHint != value)
				{
					this._floatingHint = value;
					this.OnPropertyChanged("FloatingHint");
				}
			}
		}


		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(string propertyName)
		{
			var ev = this.PropertyChanged;

			if (ev != null)
			{
				ev(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
