using System;
using System.Threading.Tasks;

namespace XamarinCleanApp.Core.Model.UseCase
{
	public abstract class UseCase<T>
	{
		public abstract T BuildUseCase();

		public async void Execute(IUseCaseCallback<T> callback)
		{
			callback.OnStartUseCase();
			try
			{
				var result = await ExecuteAsync();
				callback.OnUseCaseSuccess(result);
			}
			catch (Exception e)
			{
				callback.OnUseCaseError(e);
			}
		}

		Task<T> ExecuteAsync()
		{
			return Task.Run(() => BuildUseCase());
		}
	}
}
