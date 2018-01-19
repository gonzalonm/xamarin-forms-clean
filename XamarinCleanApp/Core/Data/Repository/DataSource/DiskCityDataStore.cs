using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using XamarinCleanApp.Core.Data.Cache;
using XamarinCleanApp.Core.Data.Entity;

namespace XamarinCleanApp.Core.Data.Repository.DataSource
{
	public class DiskCityDataStore : ICityDataStore
	{
		public ICityCache CityCache { get; set; }

		public IObservable<List<CityEntity>> GetCities()
		{
			return Observable.Create<List<CityEntity>>((emitter) =>
			{
				var list = CityCache.GetAll();
				if (list != null)
				{
					emitter.OnNext(list);
					emitter.OnCompleted();
				}
				else
				{
					emitter.OnError(new Exception("Cities were not found"));
				}

				return () => { };
			});
		}
	}
}
