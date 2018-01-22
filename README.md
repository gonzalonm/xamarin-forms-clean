# xamarin-forms-clean
Sample Xamarin.Forms application using Clean Architecture. Inspired in the done work by [Fernando Cejas](https://github.com/android10/Android-CleanArchitecture)


## Used NuGet Packages
[sqlite-net-pcl](https://github.com/praeclarum/sqlite-net): Nice ORM to store data with SQLite

[Xam.Plugin.Connectivity](https://jamesmontemagno.github.io/ConnectivityPlugin/): Plugin to detect network state

[System.Reactive.Linq](https://www.nuget.org/packages/System.Reactive.Linq/): Rx.NET plugin

## Clean Architecture
You can review the concepts of Clean Architecture in [this site](https://8thlight.com/blog/uncle-bob/2012/08/13/the-clean-architecture.html).

#### Principles

*1.* **Independent of Frameworks**. The architecture does not depend on the existence of some library of feature laden software. This allows you to use such frameworks as tools, rather than having to cram your system into their limited constraints.

*2.* **Testable**. The business rules can be tested without the UI, Database, Web Server, or any other external element.

*3.* **Independent of UI**. The UI can change easily, without changing the rest of the system. A Web UI could be replaced with a console UI, for example, without changing the business rules.

*4.* **Independent of Database**. You can swap out Oracle or SQL Server, for Mongo, BigTable, CouchDB, or something else. Your business rules are not bound to the database.

*5.* **Independent of any external agency**. In fact your business rules simply don’t know anything at all about the outside world.

![Alt text](http://jmanuelcorral.net/content/images/2016/10/1-evhm4LZIorMYVAh54cJ1Ig.png "Clean Architecture")

## Code sample
#### Observable class creation from API call.

```csharp
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
  });
```

#### Transformation from entity to a model class using a mapper

Mapper
```csharp
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
```

Transform a list of entities into a list of model class
```csharp
dataSource.Cities().Select(x => Mapper.TransformList(x));
```

#### Usecase execution

```csharp
		public void Execute(IObserver<T> observer, P param)
		{
			if (observer != null)
			{
				Task.Run(() => 
				{
					IObservable<T> observable = BuildUseCaseObservable(param);
					AddDisposable(observable.SubscribeSafe(observer));
				});
			}
		}
```


## Collaborate

You can collaborate with this project. Check the [guidelines](https://github.com/gonzalonm/xamarin-forms-clean/blob/master/.github/CONTRIBUTING.md) to contribute.


## License

```
Copyright 2018 Gonzalo Martin

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

   http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
```
