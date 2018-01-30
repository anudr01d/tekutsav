using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEKUtsav.Models;
using TEKUtsav.ViewModels.ScannerPage;
using Plugin.Vibrate;
using Xamarin.Forms;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace TEKUtsav.Views.ScannerPage
{
    public class ScannerPage : ContentPage
    {
        ZXingScannerView zxing;
        ZXingDefaultOverlay overlay;
		ScannerPageViewModel vm;

        public ScannerPage () : base ()
        {
			var options = new ZXing.Mobile.MobileBarcodeScanningOptions();
			options.AutoRotate = true;
			options.TryInverted = false;
			options.TryHarder = false;
			options.PossibleFormats = new List<ZXing.BarcodeFormat>() {
				ZXing.BarcodeFormat.All_1D,  ZXing.BarcodeFormat.AZTEC ,
				ZXing.BarcodeFormat.CODABAR, ZXing.BarcodeFormat.CODE_39 ,
				ZXing.BarcodeFormat.CODE_93 ,ZXing.BarcodeFormat.CODE_128 ,
				ZXing.BarcodeFormat.DATA_MATRIX ,ZXing.BarcodeFormat.EAN_8 ,
				ZXing.BarcodeFormat.EAN_13 ,ZXing.BarcodeFormat.ITF ,
				ZXing.BarcodeFormat.MAXICODE ,ZXing.BarcodeFormat.PDF_417 ,
				ZXing.BarcodeFormat.QR_CODE ,ZXing.BarcodeFormat.RSS_14 ,
				ZXing.BarcodeFormat.RSS_EXPANDED ,ZXing.BarcodeFormat.UPC_A ,
				ZXing.BarcodeFormat.UPC_E ,ZXing.BarcodeFormat.UPC_EAN_EXTENSION ,
				ZXing.BarcodeFormat.MSI ,ZXing.BarcodeFormat.PLESSEY , ZXing.BarcodeFormat.IMB
			};
            zxing = new ZXingScannerView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
				Options = options,
                AutomationId = "zxingScannerView",
            };
            zxing.OnScanResult += (result) => 
                Device.BeginInvokeOnMainThread (() => {

				CrossVibrate.Current.Vibration(TimeSpan.FromMilliseconds(50f));
                    zxing.IsAnalyzing = false;
					if (vm != null)
					{
						var res = new ScanResult() { ResultText=result.Text, RemoveScan = true};
						vm.MoveToNextScreenCommand.Execute(res);
					}
                    //await DisplayAlert ("Scanned Barcode", result.Text, "OK");
                    //await Navigation.PopAsync ();
                });

			overlay = new ZXingDefaultOverlay
			{
				TopText = "Align barcode in window",
				BottomText = "",
				ShowFlashButton = false,
                AutomationId = "zxingDefaultOverlay",
            };
            overlay.FlashButtonClicked += (sender, e) => {
                zxing.IsTorchOn = !zxing.IsTorchOn;
            };
			overlay.BindingContext = overlay;

            var grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            
			grid.Children.Add(zxing);
			grid.Children.Add(overlay);
            

            Content = grid;
        }

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();
			vm = (ScannerPageViewModel)this.BindingContext;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            zxing.IsScanning = true;
        }

        protected override void OnDisappearing()
        {
            zxing.IsScanning = false;

            base.OnDisappearing();
        }
    }
}
