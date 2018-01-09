using System.Collections.Generic;
using XamarinCleanApp.Core.Data.Entity;

namespace XamarinCleanApp.Core.Data.Cache
{
	public interface ICityCache
	{
		List<CityEntity> GetAll();

		CityEntity Get(int id);

		void Put(CityEntity entity);

		void PutAll(List<CityEntity> list);

		bool IsCached(int id);

		bool HasData();

		void ClearAll();
	}
}
