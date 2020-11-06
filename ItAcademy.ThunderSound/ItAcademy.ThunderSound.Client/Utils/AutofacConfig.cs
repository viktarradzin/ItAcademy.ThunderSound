using Autofac;
using Autofac.Integration.Mvc;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Repositories;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Services;
using ItAcademy.ThunderSound.DomainLayer.Services;
using ItAcademy.ThunderSound.DataLayer.Repositories;
using System.Web.Mvc;
using ItAcademy.ThunderSound.DomainLayer.Models;

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
            builder.RegisterType<TrackService>().As<ITrackService>();
            builder.RegisterType<TrackRepository>().As<ITrackRepository>();
            builder.RegisterType<SingerService>().As<ISingerService>();
            builder.RegisterType<SingerRepository>().As<ISingerRepository>();
            builder.RegisterType<PlayListService>().As<IPlayListService>();
            builder.RegisterType<PlayListRepository>().As<IPlayListRepository>();
            builder.RegisterType<GenreRepository>().As<IGenreRepository>();
            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}