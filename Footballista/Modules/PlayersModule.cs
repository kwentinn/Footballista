using Autofac;
using Footballista.BuildingBlocks.Domain.Game;
using Footballista.Game.Domain;
using Footballista.Players;
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

namespace Footballista.Modules
{
	internal class PlayersModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			// register types as interfaces
			builder.RegisterType<WeightGrowthRecordLoader>().As<IWeightGrowthRecordLoader>();
			builder.RegisterType<StatureGrowthRecordLoader>().As<IStatureGrowthRecordLoader>();
			builder.RegisterType<PercentileGrowthSetRepository>().As<IPercentileGrowthSetRepository>();
			builder.RegisterType<FirstnameRecordsLoader>().As<IFirstnameRecordsLoader>();
			builder.RegisterType<LastnameRecordsLoader>().As<ILastnameRecordsLoader>();
			builder.RegisterType<WorldCitiesLoader>().As<IWorldCitiesLoader>();
			builder.RegisterType<BirthLocationGenerator>().As<IBirthLocationGenerator>();
			builder.RegisterType<DataPathHelper>().As<IDataPathHelper>();
			builder.RegisterType<DateOfBirthGenerator>().As<IDateOfBirthGenerator>();

			builder.RegisterType<IntRandomiser>().As<IRandomiser<int>>().SingleInstance();
			builder.RegisterType<FeatureRatingRandomiser>().As<IRandomiser<Rating>>();
			builder.RegisterType<AgeRandomiser>().As<IRandomiser<PersonAge>>();
			builder.RegisterType<ListRandomiser>().As<IListRandomiser>();

			builder.RegisterType<CountriesGenerator>().As<ICountriesGenerator>();
			builder.RegisterType<FavouriteFootGenerator>().As<IFavouriteFootGenerator>();
			builder.RegisterType<GenderGenerator>().As<IGenderGenerator>();
			builder.RegisterType<GrowthSetGenerator>().As<IGrowthSetGenerator>();
			builder.RegisterType<PhysicalFeatureSetGenerator>().As<IPhysicalFeatureSetGenerator>();
			builder.RegisterType<YoungPlayerBuilder>().As<IPlayerBuilder>();
			builder.RegisterType<PercentileGenerator>().As<IPercentileGenerator>();
			builder.RegisterType<BodyMassIndexGenerator>().As<IBodyMassIndexGenerator>();
			builder.RegisterType<PlayerPositionGenerator>().As<IPlayerPositionGenerator>();
			builder.RegisterType<FirstnameGenerator>().As<IFirstnameGenerator>();
			builder.RegisterType<LastnameGenerator>().As<ILastnameGenerator>();
			builder.RegisterType<PersonNameGenerator>().As<IPersonNameGenerator>();

			// decorators
			builder.RegisterDecorator<PercentileGrowthSetRepositoryCacheDecorator, IPercentileGrowthSetRepository>();
			builder.RegisterDecorator<FirstnameRecordsLoaderCacheDecorator, IFirstnameRecordsLoader>();
			builder.RegisterDecorator<WorldCitiesLoaderCacheDecorator, IWorldCitiesLoader>();

			builder
				.Register(c => new Footballista.Game.Domain.Game("Fake career", new DateTime(2020, 1, 1)))
				.As<IGame>();
		}
	}
}
