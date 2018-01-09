using System;
using System.Collections.Generic;
using XamarinCleanApp.Core.Data.Entity;

namespace XamarinCleanApp.Core.Data.Net
{
	public interface IRestApi
	{
		List<CityEntity> GetAllCities();
	}
}
