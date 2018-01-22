using System;
using System.Collections.Generic;
using System.Net.Http;
using XamarinCleanApp.Core.Model;
using XamarinCleanApp.Core.Model.UseCase;

namespace XamarinCleanApp.Core.View.Presenter
{
	public class CityPresenter
	{
		GetAllCitiesUseCase UseCase = new GetAllCitiesUseCase();
		public CityView View { get; set; }

		public void LoadCities(bool forced)
		{
			var useCache = !forced;
			UseCase.Execute(new CityListObserver { Presenter = this}, new Params { UseCache = useCache });

			View.OnLoadingStart();
		}

		class CityListObserver : DefaultObserver<List<City>>
		{
			public CityPresenter Presenter { get; set; }

			public override void OnCompleted()
			{
				// Do nothing for now...
			}

			public override void OnError(Exception error)
			{
				if (error.InnerException is HttpRequestException && !App.IsNetworkAvailable())
				{
					Presenter.View.OnNetworkDisabledError();
				}
				else
				{
					Presenter.View.RenderError(error);
				}
			}

			public override void OnNext(List<City> value)
			{
				Presenter.View.Render(value);
			}
		}
	}
}
