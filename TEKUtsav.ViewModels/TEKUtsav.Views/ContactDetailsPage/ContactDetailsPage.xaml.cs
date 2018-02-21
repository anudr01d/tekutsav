using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEKUtsav.Infrastructure.Navigation;
using TEKUtsav.UIControls.Controls;
using Xamarin.Forms;

namespace TEKUtsav.Views.ContactDetailsPage
{
    public partial class ContactDetailsPage : TEKUtsavContentPage
    {
        public ContactDetailsPage()
        {
            InitializeComponent();

            number.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => {
                    Device.OpenUri(new Uri("tel:+917795123251"));
                })
            });
        }
	}
}
