using System.Web;
using System.Web.Mvc;
using ItAcademy.ThunderSound.Client.Models;
using ItAcademy.ThunderSound.Client.Services.Interfaces;

namespace ItAcademy.ThunderSound.Client.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class PlayListController : Controller
    {
        private readonly IPlayListPresentationService playListPresentationService;

        public PlayListController(IPlayListPresentationService playListPresentationService)
        {
            this.playListPresentationService = playListPresentationService;
        }

        public ActionResult GetImage(int id)
        {
            var image = playListPresentationService.GetImage(id);

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
            return View(playListPresentationService.GetAllPlayListsWithSingerandGenreandLabel());
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(playListPresentationService.GetPlayListById(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection formValues)
        {
            playListPresentationService.DeletePlayListById(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(playListPresentationService.GetCreatePlayListView());
        }

        [HttpPost]
        public ActionResult Create(PlayListViewModel playList, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                playListPresentationService.AddPlayList(playList, uploadImage);

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(playListPresentationService.EditPlayList(id));
        }

        [HttpPost]
        public ActionResult Edit(PlayListViewModel playList, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                playListPresentationService.EditPlayList(playList, uploadImage);

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}