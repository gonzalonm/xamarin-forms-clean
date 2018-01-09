using XamarinCleanApp.Core.Model;

namespace XamarinCleanApp.Core.Data.Entity.Mapper
{
	public class CityMapper : BaseMapper<City, CityEntity>
	{
		public override City Transform(CityEntity entity)
		{
			var city = new City
			{
				Image = entity.ImageLink,
				Name = entity.Name
			};
			return city;
		}
	}
}
