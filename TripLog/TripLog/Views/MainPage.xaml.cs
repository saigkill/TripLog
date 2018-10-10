using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TripLog.Models;
using TripLog.ViewModels;
using TripLog.Services;

namespace TripLog.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

		}

        MainViewModel _vm
        {
            get { return BindingContext as MainViewModel; }
        }

        void New_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewEntryPage());
        }

        async void Trips_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var trip = (TripLogEntry)e.Item;            
            _vm.ViewCommand.Execute(trip);

            // Clear selection
            trips.SelectedItem = null;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing ();

            // Initialize MainViewModel
            if (_vm != null)
                await _vm.Init();
        }
    }
}
