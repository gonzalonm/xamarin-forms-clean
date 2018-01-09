using System;
using System.Collections.Generic;
using XamarinCleanApp.Core.Model;

namespace XamarinCleanApp.Core.View
{
	public interface CityView
	{
		void OnLoadingStart();

		void Render(List<City> list);

		void RenderError(Exception error);

		void OnNetworkDisabledError();
	}
}
