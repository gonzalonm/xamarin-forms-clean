using System;
namespace XamarinCleanApp.Core.Model.UseCase
{
	public interface IUseCaseCallback<T>
	{
		void OnStartUseCase();
		void OnUseCaseSuccess(T data);
		void OnUseCaseError(Exception error);
	}
}
