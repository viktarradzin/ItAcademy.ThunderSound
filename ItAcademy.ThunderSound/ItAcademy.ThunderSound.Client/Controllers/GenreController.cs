using System.Web;
using System.Web.Mvc;
using ItAcademy.ThunderSound.Client.Models;
using ItAcademy.ThunderSound.Client.Services.Interfaces;

namespace ItAcademy.ThunderSound.Client.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class GenreController : Controller
    {
        private readonly IGenrePresentationService genrePresentationService;

        public GenreController(IGenrePresentationService genrePresentationService)
        {
            this.genrePresentationService = genrePresentationService;
        }

        public ActionResult Index()
        {
            return View(genrePresentationService.GetAllGenres());
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(genrePresentationService.GetGenreById(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection formValues)
        {
            genrePresentationService.DeleteGenreById(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GenreViewModel genre, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                genrePresentationService.AddGenre(genre, uploadImage);

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
            return View(genrePresentationService.GetGenreById(id));
        }

        [HttpPost]
        public ActionResult Edit(GenreViewModel genre)
        {
            if (ModelState.IsValid)
            {
                genrePresentationService.EditGenre(genre);

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult GetImage(int id)
        {
            var image = genrePresentationService.GetImage(id);

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