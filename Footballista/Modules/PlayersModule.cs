using Autofac;
using Footballista.Players.Growths;
using Footballista.Players.Infrastracture.Loaders.Firstnames;
using Footballista.Players.Infrastracture.Loaders.Growths;
using Footballista.Players.Infrastracture.Loaders.Lastnames;
using Footballista.Players.Infrastracture.Repositories;
using Footballista.Players.Infrastracture.Repositories.Decorators;
using System.Reflection;

namespace Footballista.Modules
{
	internal class PlayersModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			//builder
			//	.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
			//	.AsImplementedInterfaces();

			//builder
			//	.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(FirstnameRecordsLoader)))
			//	.AsImplementedInterfaces();
			builder.RegisterType<WeightGrowthRecordLoader>().As<IWeightGrowthRecordLoader>();
			builder.RegisterType<StatureGrowthRecordLoader>().As<IStatureGrowthRecordLoader>();
			builder.RegisterType<PercentileGrowthSetRepository>().As<IPercentileGrowthSetRepository>();
			builder.RegisterType<FirstnameRecordsLoader>().As<IFirstnameRecordsLoader>();
			builder.RegisterType<LastnameRecordsLoader>().As<ILastnameRecordsLoader>();

			builder.RegisterDecorator<PercentileGrowthSetRepositoryCacheDecorator, IPercentileGrowthSetRepository>();
			builder.RegisterDecorator<FirstnameRecordsLoaderCacheDecorator, IFirstnameRecordsLoader>();
		}
	}
}
