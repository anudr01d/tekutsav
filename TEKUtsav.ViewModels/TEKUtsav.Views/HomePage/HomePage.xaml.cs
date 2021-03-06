﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEKUtsav.Infrastructure.Navigation;
using TEKUtsav.UIControls.Controls;
using TEKUtsav.ViewModels.HomePage;
using Xamarin.Forms;

namespace TEKUtsav.Views.HomePage
{
    public partial class HomePage : TEKUtsavContentPage, ICanHideBackButton
    {
        HomePageViewModel vm;

        public HomePage()
        {
            InitializeComponent();
            HideBackButton = true;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            vm = (HomePageViewModel)this.BindingContext;
            //if (wvPlayer != null)
            //{
            //    wvPlayer.HeightRequest = 200;
            //    wvPlayer.Source = new HtmlWebViewSource
            //    {
            //        Html = BuildEmbedUrl("https://www.youtube.com/watch?v=a2A2APdahn4")
            //    };
            //}

        }

        public static string BuildEmbedUrl(string videoSource)
        {
            var iframeURL = string.Format("<iframe src=\"{0}\" frameborder=\"0\" allowfullscreen></iframe>", videoSource);
            return string.Format("<html><body>{0}</body></html>", iframeURL);
        }


        public bool HideBackButton { get; set; }

        void Handle_PositionSelected(object sender, CarouselView.FormsPlugin.Abstractions.PositionSelectedEventArgs e)
        {
            Debug.WriteLine("Position " + e.NewValue + " selected.");
        }

        void Handle_Scrolled(object sender, CarouselView.FormsPlugin.Abstractions.ScrolledEventArgs e)
        {
            Debug.WriteLine("Scrolled to " + e.NewValue + " percent.");
            Debug.WriteLine("Direction = " + e.Direction);
        }
    }
}
