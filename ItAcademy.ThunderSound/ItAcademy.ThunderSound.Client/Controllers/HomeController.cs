    using System.Web.Mvc;
    using ItAcademy.ThunderSound.Client.Services.Interfaces;

    namespace ItAcademy.ThunderSound.Client.Controllers
    {
    [Authorize(Roles = "User, Admin")]
    public class HomeController : Controller
    {
        private readonly IHomePresentationService homePresentationService;
        private readonly ITrackPresentationService trackPresentationService;
        private readonly ISingerPresentationService singerPresentationService;
        private readonly IPlayListPresentationService playListPresentationService;

        public HomeController (
            IHomePresentationService homePresentationService,
            ITrackPresentationService trackPresentationService,
            ISingerPresentationService singerPresentationService,
            IPlayListPresentationService playListPresentationService)
        {
            this.singerPresentationService = singerPresentationService;
            this.homePresentationService = homePresentationService;
            this.trackPresentationService = trackPresentationService;
            this.playListPresentationService = playListPresentationService;
        }

        public ActionResult Index()
        {
            return View(homePresentationService.GetSixRandomTrackWithPlayList());
        }

        public ActionResult Audio(int id)
        {
            return new FileStreamResult(trackPresentationService.MemoryStream(id), "audio/mp3");
        }

        public ActionResult GetImage(int id)
        {
            var image = homePresentationService.GetImage(id);

            if (image != null)
            {
                return File(image, "image/jpg");
            }
            else
            {
                return null;
            }
        }
    }
}