using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using FluentValidation.Mvc;
using ItAcademy.ThunderSound.Client.App_Start;
using ItAcademy.ThunderSound.Client.Util.Logging;
using ItAcademy.ThunderSound.Client.Utils;

namespace ItAcademy.ThunderSound.Client
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.ConfigureContainer();

            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.Initialize(cfg =>
            {
                AutoMapperConfig.Configure(cfg);
            });

            FluentValidationModelValidatorProvider.Configure();

            Logger.InitLogger();

            Logger.Log.Info("Start Application.");
        }

        protected void Application_End()
        {
            Logger.InitLogger();

            Logger.Log.Info("End Application.");
        }
    }
}
