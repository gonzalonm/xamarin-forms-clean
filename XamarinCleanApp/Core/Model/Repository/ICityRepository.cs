using System;
using System.Collections.Generic;

namespace XamarinCleanApp.Core.Model.Repository
{
	public interface ICityRepository
	{
		IObservable<List<City>> GetCities(bool useCache);
	}
}
