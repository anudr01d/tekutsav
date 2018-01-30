using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace TEKUtsav.UIControls.Controls
{
	public class MVVMWebView : WebView
	{
		public static readonly BindableProperty NavigatingCommandProperty =
			BindableProperty.Create(nameof(NavigatingCommand), typeof(ICommand), typeof(MVVMWebView), null);

		public static readonly BindableProperty NavigatedCommandProperty =
			BindableProperty.Create(nameof(NavigatedCommand), typeof(ICommand), typeof(MVVMWebView), null);

		public MVVMWebView()
		{
			Navigating += (s, e) =>
			{
				if (NavigatingCommand?.CanExecute(e) ?? false)
					NavigatingCommand.Execute(e);
			};

			Navigated += (s, e) =>
			{
				if (NavigatedCommand?.CanExecute(e) ?? false)
					NavigatedCommand.Execute(e);
			};

	}

		public ICommand NavigatingCommand
		{
			get { return (ICommand)GetValue(NavigatingCommandProperty); }
			set { SetValue(NavigatingCommandProperty, value); }
		}

		public ICommand NavigatedCommand
		{
			get { return (ICommand)GetValue(NavigatedCommandProperty); }
			set { SetValue(NavigatedCommandProperty, value); }
		}
	}
}