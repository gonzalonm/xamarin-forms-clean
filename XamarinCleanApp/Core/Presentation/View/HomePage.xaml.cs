using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using XamarinCleanApp.Core.Model;
using XamarinCleanApp.Core.View.Presenter;

namespace XamarinCleanApp.Core.View
{
	public partial class HomePage : ContentPage, CityView
	{
		enum ViewState
		{
			Normal, Error, Loading, Offline
		}

		public ObservableCollection<City> CityList { get; set; }
		CityPresenter Presenter;

		public HomePage()
		{
			InitializeComponent();

			Title = "Xamarin Clean Architecture";

			CityList = new ObservableCollection<City>();
			Presenter = new CityPresenter { View = this };
			UpdateData(false);
		}

		#region View commands
		public void OnRefresh(object sender, EventArgs e)
		{
			// force to retrieve all post from server
			UpdateData(true);
		}

		public async void OnTap(object sender, ItemTappedEventArgs e)
		{
			var item = e.Item as City;
			await DisplayAlert("City", item.Name, "OK");
		}
		#endregion View commands

		public void OnLoadingStart()
		{
			UpdateViewState(ViewState.Loading);
		}

		public void Render(List<City> list)
		{
			Device.BeginInvokeOnMainThread(() => 
			{
				CityList.Clear();
				foreach (var item in list)
				{
					CityList.Add(item);
				}
				ListView.ItemsSource = CityList;

				//make sure to end the refresh state
				ListView.IsRefreshing = false;

				UpdateViewState(ViewState.Normal);
			});
		}

		public async void RenderError(Exception error)
		{
			await DisplayAlert("Error", error.InnerException.ToString(), "OK");
		}

		public void OnNetworkDisabledError()
		{
			ListView.IsRefreshing = false;
			UpdateViewState(ViewState.Offline);
		}

		void UpdateData(bool forced)
		{
			UpdateViewState(ViewState.Loading);
			Presenter.LoadCities(forced);
		}

		void UpdateViewState(ViewState viewState)
		{
			switch (viewState)
			{
				case ViewState.Normal:
					ErrorLayout.IsVisible = false;
					ProgressLayout.IsVisible = false;
					ListView.IsVisible = true;
					break;
				case ViewState.Loading:
					if (!ListView.IsRefreshing)
					{
						ErrorLayout.IsVisible = false;
						ProgressLayout.IsVisible = true;
						ListView.IsVisible = false;	
					}
					break;
				case ViewState.Error:
					ErrorTitle.Text = "Error";
					ErrorMessage.Text = "An error occurred";
					ErrorLayout.IsVisible = true;
					ProgressLayout.IsVisible = false;
					ListView.IsVisible = false;
					break;
				case ViewState.Offline:
					ErrorTitle.Text = "Error";
					ErrorMessage.Text = "Network Not Connected";
					ErrorLayout.IsVisible = true;
					ProgressLayout.IsVisible = false;
					ListView.IsVisible = false;
					break;
			}
		}
	}
}
