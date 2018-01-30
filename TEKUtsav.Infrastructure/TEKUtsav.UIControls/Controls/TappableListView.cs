using System.Windows.Input;
using Xamarin.Forms;
using TEKUtsav.UIControls.Styles;

namespace TEKUtsav.UIControls.Controls
{
    public class TappableListView : Xamarin.Forms.ListView
    {
        public static BindableProperty ItemClickCommandProperty =
            BindableProperty.Create<TappableListView, ICommand>(x => x.ItemClickCommand, null);

        public TappableListView()
        {
            this.ItemTapped += this.OnItemTapped;
            var TEKUtsavListViewStyle = new TEKUtsavListViewStyle();
            this.Resources = TEKUtsavListViewStyle.Resources;
            this.Style = (Style)Resources["ListviewBgColor"];
        }
        public ICommand ItemClickCommand
        {
            get { return (ICommand)this.GetValue(ItemClickCommandProperty); }
            set { this.SetValue(ItemClickCommandProperty, value); }
        }



        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null && this.ItemClickCommand != null && this.ItemClickCommand.CanExecute(e))
            {
                this.ItemClickCommand.Execute(e.Item);
                this.SelectedItem = e.Item;
            }

        }
    }
}
