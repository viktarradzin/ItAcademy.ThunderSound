using System.Web;
using System.Web.Mvc;
using ItAcademy.ThunderSound.Client.Models;
using ItAcademy.ThunderSound.Client.Services.Interfaces;

namespace ItAcademy.ThunderSound.Client.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class LabelController : Controller
    {
        private readonly ILabelPresentationService labelPresentationService;

        public LabelController(ILabelPresentationService labelPresentationService)
        {
            this.labelPresentationService = labelPresentationService;
        }

        public ActionResult GetImage(int id)
        {
            var image = labelPresentationService.GetImage(id);

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
            return View(labelPresentationService.GetAllLabels());
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(labelPresentationService.GetLabelById(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection formValues)
        {
            labelPresentationService.DeleteLabelById(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(LabelViewModel label, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                labelPresentationService.AddLabel(label, uploadImage);

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
            return View(labelPresentationService.EditLabel(id));
        }

        [HttpPost]
        public ActionResult Edit(LabelViewModel label, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                labelPresentationService.EditLabel(label, uploadImage);

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}