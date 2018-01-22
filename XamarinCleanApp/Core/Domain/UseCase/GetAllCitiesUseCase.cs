using System;
using System.Collections.Generic;
using XamarinCleanApp.Core.Data.Repository;
using XamarinCleanApp.Core.Model.Repository;

namespace XamarinCleanApp.Core.Model.UseCase
{
	public class GetAllCitiesUseCase : UseCase<List<City>, Params>
	{
		ICityRepository Repository = new CityRepository();

		public override IObservable<List<City>> BuildUseCaseObservable(Params param)
		{
			return Repository.Cities(param.UseCache);
		}
	}

	public class Params
	{
		public bool UseCache { get; set; }
	}
}
