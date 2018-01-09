using Plugin.Connectivity;
using Xamarin.Forms;
using XamarinCleanApp.Core.Data.Cache;
using XamarinCleanApp.Core.Data.Cache.Database;
using XamarinCleanApp.Core.View;

namespace XamarinCleanApp
{
	public partial class App : Application
	{
		const string AppDatabaseName = "XamarinCleanApp.db3";
		static AppDatabase database;

		public App()
		{
			InitializeComponent();

			var page = new NavigationPage(new HomePage());
			MainPage = page;
		}

		public static AppDatabase Database
		{
			get
			{
				if (database == null)
				{
					database = new AppDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath(AppDatabaseName));
				}
				return database;
			}
		}

		public static bool IsNetworkAvailable()
		{
			return CrossConnectivity.Current.IsConnected;
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
