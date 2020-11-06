using System.Web;
using System.Web.Mvc;
using ItAcademy.ThunderSound.Client.Models;
using ItAcademy.ThunderSound.Client.Services.Interfaces;

namespace ItAcademy.ThunderSound.Client.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class SingerController : Controller
    {
        private readonly ISingerPresentationService singerPresentationService;

        private readonly ITrackPresentationService trackPresentationService;

        public SingerController(ISingerPresentationService singerPresentationService, ITrackPresentationService trackPresentationService)
        {
            this.singerPresentationService = singerPresentationService;
            this.trackPresentationService = trackPresentationService;
        }

        public ActionResult GetImage(int id)
        {
            var image = singerPresentationService.GetImage(id);

            if (image != null)
            {
                return File(image, "image/jpg");
            }
            else
            {
                return null;
            }
        }

        public ActionResult Index()
        {
            return View(singerPresentationService.GetAllSingersWithGenre());
        }

        public ActionResult Audio(int id)
        {
            return new FileStreamResult(trackPresentationService.MemoryStream(id), "audio/mp3");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(singerPresentationService.GetCreateSingerView());
        }

        [HttpPost]
        public ActionResult Create(SingerViewModel singerView, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                singerPresentationService.AddSinger(singerView, uploadImage);

                return View("Index", singerPresentationService.GetAllSingersWithGenre());
            }
            else
            {
                return View("Create", singerPresentationService.GetCreateSingerView());
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(singerPresentationService.GetOneSingerViewByIdWithGenre(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection formValues)
        {
            singerPresentationService.DeleteSingerById(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var singer = singerPresentationService.GetOneSingerViewByIdWithGenre(id);
            return View("Edit", singer);
        }

        [HttpPost]
        public ActionResult Edit(SingerViewModel singer, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                singerPresentationService.EditSinger(singer, uploadImage);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit", singerPresentationService.GetOneSingerViewByIdWithGenre(singer.SingerId));
            }
        }
    }
}