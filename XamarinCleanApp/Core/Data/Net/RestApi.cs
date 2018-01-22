using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using XamarinCleanApp.Core.Data.Cache;
using XamarinCleanApp.Core.Data.Entity;

namespace XamarinCleanApp.Core.Data.Net
{
	public class RestApi : IRestApi
	{
		Serializer<List<CityEntity>> CityEntitySerializer = new Serializer<List<CityEntity>>();

		public IObservable<List<CityEntity>> Cities()
		{
			return Observable.Create<List<CityEntity>>((emitter) =>
			{
				var json = GetAllCitiesFromApi();

				if (json != null)
				{
					emitter.OnNext(CityEntitySerializer.FromJson(json));
					emitter.OnCompleted();
				}
				else
				{
					emitter.OnError(new Exception("Cities were not found"));
				}

				return () => { };
			});
		}

		string GetAllCitiesFromApi()
		{
			var url = ApiConnection.HostUrl;
			return ApiConnection.DoGet(url).Result;
		}
	}
}
