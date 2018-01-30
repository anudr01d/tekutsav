using System;
using TEKUtsav.iOS;
using TEKUtsav.iOS;
using TEKUtsav.UIControls.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(PoListViewCell), typeof(PoListViewCellRenderer))]
namespace TEKUtsav.iOS
{
	public class PoListViewCellRenderer : ViewCellRenderer
	{
		private UIView bgView;

		public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
		{
			var cell = base.GetCell(item, reusableCell, tv);
			cell.BackgroundColor = UIColor.White;
			cell.TextLabel.TextColor = UIColor.White;

			if (bgView == null)
			{
				bgView = new UIView(cell.SelectedBackgroundView.Bounds)
				{
					BackgroundColor = UIColor.Clear.FromHex(0xF5F5F5)
				};
			}

			cell.SelectedBackgroundView = bgView;

			return cell;
		}
	}
}
