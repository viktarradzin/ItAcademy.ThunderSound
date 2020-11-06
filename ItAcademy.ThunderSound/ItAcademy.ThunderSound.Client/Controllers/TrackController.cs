using System.Web.Mvc;
using ItAcademy.ThunderSound.Client.Models;
using ItAcademy.ThunderSound.Client.Services.Interfaces;

namespace ItAcademy.ThunderSound.Client.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class TrackController : Controller
    {
        private readonly ITrackPresentationService trackPresentationService;

        public TrackController(ITrackPresentationService trackPresentationService)
        {
            this.trackPresentationService = trackPresentationService;
        }

        public ActionResult Index()
        {
            return View(trackPresentationService.GetAllTracksWithSingerandGenresAndPlayLists());
        }

        [AllowAnonymous]
        public ActionResult Audio(int id)
        {
            return new FileStreamResult(trackPresentationService.MemoryStream(id), "audio/mp3");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(trackPresentationService.GetOneTrackViewById(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection formValues)
        {
            trackPresentationService.DeleteTrackById(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(trackPresentationService.GetCreateTrackView());
        }

        [HttpPost]
        public ActionResult Create(TrackViewModel track)
        {
            if (ModelState.IsValid)
            {
                trackPresentationService.AddTrack(track);

                return View("Index", trackPresentationService.GetAllTracksWithSingerandGenresAndPlayLists());
            }
            else
            {
                return View("Create", trackPresentationService.GetCreateTrackView());
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(trackPresentationService.EditTrack(id));
        }

        [HttpPost]
        public ActionResult Edit(TrackViewModel track)
        {
            if (ModelState.IsValid)
            {
                trackPresentationService.EditTrack(track);

                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit", trackPresentationService.EditTrack(track.TrackId));
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult GetSinger(string genreId)
        {
            return Json(trackPresentationService.GetSingersSelectListItem(genreId), JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult GetPlayList(string singerId)
        {
            return Json(trackPresentationService.GetPlayListsSelectListItem(singerId), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetImage(int id)
        {
            var image = trackPresentationService.GetImage(id);

            if (image != null)
            {
                return File(image, "image/jpg");
            }
            else
            {
                return null;
            }
        }

        public ActionResult Genre(int id)
        {
            return View("Index", trackPresentationService.GetTracksWithPlayListandSingerByGenreId(id));
        }

        public ActionResult PlayList(int id)
        {
            return View("Index", trackPresentationService.GetTracksWithGenreWithSingerByPlayListId(id));
        }

        public ActionResult Singer(int id)
        {
            return View("Index", trackPresentationService.GetTracksWithGenreWithPlayListBySingerId(id));
        }
    }
}
