using Autofac;
using Footballista.BuildingBlocks.Domain.Game;
using Footballista.Game.Domain;
using Footballista.Players.Builders.Generators;
using Footballista.Players.Builders.Randomisers;
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
			builder.RegisterType<NameGenerator>().As<INameGenerator>();
			builder.RegisterType<DateOfBirthGenerator>().As<IDateOfBirthGenerator>();
			builder.RegisterType<ListRandomiser>().As<IListRandomiser>();

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
