using Autofac;
using Footballista.Game.Domain;
using Footballista.Game.Domain.Careers;
using Footballista.Game.Domain.Clubs;
using Footballista.Game.Domain.Competitions;
using Footballista.Game.Domain.Competitions.Seasons;
using Footballista.Game.Infrastructure;

namespace Footballista.Wasm.Server.Configuration.AutofacModules
{
    internal class GameModule : Module
    {
		protected override void Load(ContainerBuilder builder)
        {
			builder.RegisterType<CareerRepository>().As<ICareerRepository>().InstancePerLifetimeScope();
			builder.RegisterType<ClubRepository>().As<IClubRepository>().InstancePerLifetimeScope();
			builder.RegisterType<CareerDomainService>().As<ICareerDomainService>().InstancePerLifetimeScope();
			builder.RegisterType<SeasonRepository>().As<ISeasonRepository>().InstancePerLifetimeScope();
			builder.RegisterType<CompetitionRepository>().As<ICompetitionRepository>().InstancePerLifetimeScope();
        }
    }

    internal static class BuilderExtensions
    {
        public static ContainerBuilder RegisterGameModule(this ContainerBuilder builder)
        {
            builder.RegisterModule(new GameModule());
            return builder;
        }
    }
}
