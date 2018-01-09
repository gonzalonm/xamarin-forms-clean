using System.Collections.Generic;
using XamarinCleanApp.Core.Data.Repository;
using XamarinCleanApp.Core.Model.Repository;

namespace XamarinCleanApp.Core.Model.UseCase
{
	public class GetAllCitiesUseCase : UseCase<List<City>>
	{
		ICityRepository Repository;

		public GetAllCitiesUseCase(bool useCache)
		{
			Repository = new CityRepository(useCache);
		}

		public override List<City> BuildUseCase()
		{
			return Repository.Cities();
		}
	}
}
