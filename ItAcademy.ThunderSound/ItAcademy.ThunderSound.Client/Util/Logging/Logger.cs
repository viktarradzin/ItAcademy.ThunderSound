using log4net;
using log4net.Config;

namespace ItAcademy.ThunderSound.Client.Util.Logging
{
    public static class Logger
    {
        public static ILog Log { get; } = LogManager.GetLogger("LOGGER");

        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }
    }
}