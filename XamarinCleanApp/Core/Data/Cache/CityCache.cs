using System;
using System.Collections.Generic;
using XamarinCleanApp.Core.Data.Entity;

namespace XamarinCleanApp.Core.Data.Cache
{
	public class CityCache : ICityCache
	{
		public void ClearAll()
		{
			var list = GetAll();
			foreach (var entity in list)
			{
				App.Database.Delete(entity);
			}
		}

		public CityEntity Get(int id)
		{
			return App.Database.FindById(id);
		}

		public List<CityEntity> GetAll()
		{
			return App.Database.FindAll();
		}

		public bool HasData()
		{
			return GetAll().Count > 0;
		}

		public bool IsCached(int id)
		{
			return Get(id) != null;
		}

		public void Put(CityEntity entity)
		{
			App.Database.InsertOrUpdate(entity);
		}

		public void PutAll(List<CityEntity> list)
		{
			App.Database.InsertAll(list);
		}
	}
}
