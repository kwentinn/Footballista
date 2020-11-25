using Autofac;
using Footballista.BuildingBlocks.Domain.Game;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Builders;
using Footballista.Players.Builders.Generators;
using Footballista.Players.Builders.Randomisers;
using Footballista.Players.Features;
using Footballista.Players.Growths;
using Footballista.Players.Infrastracture.Generators;
using Footballista.Players.Infrastracture.Loaders;
using Footballista.Players.Infrastracture.Loaders.Cities;
using Footballista.Players.Infrastracture.Loaders.Firstnames;
using Footballista.Players.Infrastracture.Loaders.Growths;
using Footballista.Players.Infrastracture.Loaders.Lastnames;
using Footballista.Players.Infrastracture.Repositories;
using Footballista.Players.Infrastracture.Repositories.Decorators;
using System;

namespace Footballista.Wasm.Server.Configuration.AutofacModules
{
	internal class PlayersModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			// register types as interfaces
			builder.RegisterType<WeightGrowthRecordLoader>().As<IWeightGrowthRecordLoader>().SingleInstance();
			builder.RegisterType<StatureGrowthRecordLoader>().As<IStatureGrowthRecordLoader>().SingleInstance();
			builder.RegisterType<PercentileGrowthSetRepository>().As<IPercentileGrowthSetRepository>().SingleInstance();
			builder.RegisterType<FirstnameRecordsLoader>().As<IFirstnameRecordsLoader>().SingleInstance();
			builder.RegisterType<LastnameRecordsLoader>().As<ILastnameRecordsLoader>().SingleInstance();
			builder.RegisterType<WorldCitiesLoader>().As<IWorldCitiesLoader>().SingleInstance();
			builder.RegisterType<BirthLocationGenerator>().As<IBirthLocationGenerator>().SingleInstance();
			builder.RegisterType<DataPathHelper>().As<IDataPathHelper>().SingleInstance();
			builder.RegisterType<DateOfBirthGenerator>().As<IDateOfBirthGenerator>().SingleInstance();

			builder.RegisterType<IntRandomiser>().As<IRandomiser<int>>().SingleInstance();
			builder.RegisterType<MultipleIntValuesRandomiser>().As<IMultipleValuesRandomiser<int>>().SingleInstance();
			builder.RegisterType<FeatureRatingRandomiser>().As<IRandomiser<Rating>>().SingleInstance();
			builder.RegisterType<AgeRandomiser>().As<IRandomiser<PersonAge>>().SingleInstance();
			builder.RegisterType<ListRandomiser>().As<IListRandomiser>().SingleInstance();

			builder.RegisterType<CountriesGenerator>().As<ICountriesGenerator>().SingleInstance();
			builder.RegisterType<FavouriteFootGenerator>().As<IFavouriteFootGenerator>().SingleInstance();
			builder.RegisterType<GenderGenerator>().As<IGenderGenerator>().SingleInstance();
			builder.RegisterType<GrowthSetGenerator>().As<IGrowthSetGenerator>().SingleInstance();
			builder.RegisterType<PhysicalFeatureSetGenerator>().As<IPhysicalFeatureSetGenerator>().SingleInstance();
			builder.RegisterType<YoungPlayerGenerator>().As<IPlayerGenerator>().SingleInstance();
			builder.RegisterType<PercentileGenerator>().As<IPercentileGenerator>().SingleInstance();
			builder.RegisterType<BodyMassIndexGenerator>().As<IBodyMassIndexGenerator>().SingleInstance();
			builder.RegisterType<PlayerPositionGenerator>().As<IPlayerPositionGenerator>().SingleInstance();
			builder.RegisterType<FirstnameGenerator>().As<IFirstnameGenerator>().SingleInstance();
			builder.RegisterType<LastnameGenerator>().As<ILastnameGenerator>().SingleInstance();
			builder.RegisterType<PersonNameGenerator>().As<IPersonNameGenerator>().SingleInstance();

			// decorators
			builder.RegisterDecorator<PercentileGrowthSetRepositoryCacheDecorator, IPercentileGrowthSetRepository>();
			builder.RegisterDecorator<FirstnameRecordsLoaderCacheDecorator, IFirstnameRecordsLoader>();
			builder.RegisterDecorator<WorldCitiesLoaderCacheDecorator, IWorldCitiesLoader>();

			builder
				.Register(c => new Game.Domain.Game("Fake career", new DateTime(2020, 1, 1)))
				.As<IGame>();
		}
	}
}
