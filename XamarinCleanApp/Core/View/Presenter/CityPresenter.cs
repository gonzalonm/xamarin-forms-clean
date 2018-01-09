using System;
using System.Collections.Generic;
using System.Net.Http;
using XamarinCleanApp.Core.Model;
using XamarinCleanApp.Core.Model.UseCase;

namespace XamarinCleanApp.Core.View.Presenter
{
	public class CityPresenter
	{
		GetAllCitiesUseCase UseCase;
		public CityView View { get; set; }

		public void LoadCities(bool forced)
		{
			var useCache = !forced;
			UseCase = new GetAllCitiesUseCase(useCache);
			UseCase.Execute(new GetAllCitiesUseCaseCallback { Presenter = this });
		}

		class GetAllCitiesUseCaseCallback : IUseCaseCallback<List<City>>
		{
			public CityPresenter Presenter { get; set; }

			public void OnStartUseCase()
			{
				Presenter.View.OnLoadingStart();
			}

			public void OnUseCaseError(Exception error)
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

			public void OnUseCaseSuccess(List<City> data)
			{
				Presenter.View.Render(data);
			}
		}
	}
}
