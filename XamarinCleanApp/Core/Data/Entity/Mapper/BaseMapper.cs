using System.Collections.Generic;

namespace XamarinCleanApp.Core.Data.Entity.Mapper
{
	public abstract class BaseMapper<Model, Entity>
	{
		public abstract Model Transform(Entity entity);

		public List<Model> TransformList(List<Entity> list)
		{
			var result = new List<Model>();
			foreach (var entity in list)
			{
				result.Add(Transform(entity));
			}
			return result;
		}
	}
}
