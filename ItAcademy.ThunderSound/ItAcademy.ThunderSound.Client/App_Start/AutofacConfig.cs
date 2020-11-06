using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using FluentValidation;
using FluentValidation.Mvc;
using ItAcademy.ThunderSound.Client.App_Start;
using ItAcademy.ThunderSound.Client.Services;
using ItAcademy.ThunderSound.Client.Services.Interfaces;
using ItAcademy.ThunderSound.Client.Util.Validators;
using ItAcademy.ThunderSound.DataLayer.Context;
using ItAcademy.ThunderSound.DataLayer.Repositories;
using ItAcademy.ThunderSound.DataLayer.UnitOfWork;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Repositories;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Services;
using ItAcademy.ThunderSound.DomainLayer.Services;
using ItAcademy.ThunderSound.DomainLayer.UnitOfWork;

namespace ItAcademy.ThunderSound.Client.Utils
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();

            // регистрируем контроллер в текущей сборке
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // регистрируем споставление типов
            // Presentation Services
            builder.RegisterType<TrackPresentationService>().As<ITrackPresentationService>().InstancePerDependency();
            builder.RegisterType<SingerPresentationService>().As<ISingerPresentationService>().InstancePerDependency();
            builder.RegisterType<GenrePresentationService>().As<IGenrePresentationService>().InstancePerDependency();
            builder.RegisterType<PlayListPresentationService>().As<IPlayListPresentationService>().InstancePerDependency();
            builder.RegisterType<LabelPresentationService>().As<ILabelPresentationService>().InstancePerDependency();
            builder.RegisterType<HomePresentationService>().As<IHomePresentationService>().InstancePerDependency();

            // Domain Services
            builder.RegisterType<TrackDomainService>().As<ITrackDomainService>().InstancePerDependency();
            builder.RegisterType<SingerDomainService>().As<ISingerDomainService>().InstancePerDependency();
            builder.RegisterType<GenreDomainService>().As<IGenreDomainService>().InstancePerDependency();
            builder.RegisterType<PlayListDomainService>().As<IPlayListDomainService>().InstancePerDependency();
            builder.RegisterType<LabelDomainService>().As<ILabelDomainService>().InstancePerDependency();

            // Repositories
            builder.RegisterType<TrackRepository>().As<ITrackRepository>().InstancePerDependency();
            builder.RegisterType<SingerRepository>().As<ISingerRepository>().InstancePerDependency();
            builder.RegisterType<GenreRepository>().As<IGenreRepository>().InstancePerDependency();
            builder.RegisterType<PlayListRepository>().As<IPlayListRepository>().InstancePerDependency();
            builder.RegisterType<LabelRepository>().As<ILabelRepository>().InstancePerDependency();

            // Others
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<ThunderSoundDbContext>().As<IThunderSoundDbContext>().InstancePerLifetimeScope();

            AssemblyScanner.FindValidatorsInAssemblyContaining<TrackValidator>().ForEach(result =>
            {
                builder.RegisterType(result.ValidatorType).AsImplementedInterfaces().InstancePerLifetimeScope();
            });

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            var dependencyResolver = new AutofacDependencyResolver(container);

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(dependencyResolver);

            FluentValidationModelValidatorProvider.Configure(config =>
            {
                config.ValidatorFactory = new AutofacValidatorFactory(dependencyResolver);
            });
        }
    }
}