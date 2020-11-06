using System.Collections.Generic;
using System.Web;
using ItAcademy.ThunderSound.Client.Models;

namespace ItAcademy.ThunderSound.Client.Services.Interfaces
{
    public interface ILabelPresentationService
    {
        List<LabelViewModel> GetAllLabels();

        LabelViewModel GetLabelById(int id);

        LabelViewModel EditLabel(int id);

        void EditLabel(LabelViewModel genreView, HttpPostedFileBase uploadImage);

        void AddLabel(LabelViewModel genreView, HttpPostedFileBase uploadImage);

        void DeleteLabelById(int id);

        byte[] GetImage(int id);
    }
}