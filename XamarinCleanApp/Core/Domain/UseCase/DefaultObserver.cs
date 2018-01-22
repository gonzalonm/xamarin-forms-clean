using System;
namespace XamarinCleanApp.Core.Model.UseCase
{
	public class DefaultObserver<T> : IObserver<T>
	{
		public virtual void OnCompleted()
		{
			// no-op by default.
		}

		public virtual void OnError(Exception error)
		{
			// no-op by default.
		}

		public virtual void OnNext(T value)
		{
			// no-op by default.
		}
	}
}
