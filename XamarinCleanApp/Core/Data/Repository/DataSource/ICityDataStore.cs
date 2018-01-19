using System;
using System.Collections.Generic;
using XamarinCleanApp.Core.Data.Entity;

namespace XamarinCleanApp.Core.Data.Repository.DataSource
{
	public interface ICityDataStore
	{
		IObservable<List<CityEntity>> GetCities();
	}
}
