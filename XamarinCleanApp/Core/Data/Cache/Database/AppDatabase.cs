using System.Collections.Generic;
using SQLite;
using XamarinCleanApp.Core.Data.Entity;

namespace XamarinCleanApp.Core.Data.Cache.Database
{
	public class AppDatabase
	{
		readonly SQLiteAsyncConnection CityDatabase;

		public AppDatabase(string dbPath)
		{
			CityDatabase = new SQLiteAsyncConnection(dbPath);
			CreateTables();
		}

		void CreateTables()
		{
			CityDatabase.CreateTableAsync<CityEntity>().Wait();
		}

		public List<CityEntity> FindAll()
		{
			return CityDatabase.Table<CityEntity>().ToListAsync().Result;
		}

		public CityEntity FindById(int id)
		{
			return CityDatabase.Table<CityEntity>().Where(i => i.ID == id).FirstOrDefaultAsync().Result;
		}

		public int InsertOrUpdate(CityEntity entity)
		{
			if (entity.ID != 0)
			{
				return CityDatabase.UpdateAsync(entity).Result;
			}
			return CityDatabase.InsertAsync(entity).Result;
		}

		public int InsertAll(List<CityEntity> list)
		{
			return CityDatabase.InsertAllAsync(list).Result;
		}

		public int Delete(CityEntity entity)
		{
			return CityDatabase.DeleteAsync(entity).Result;
		}
	}
}
