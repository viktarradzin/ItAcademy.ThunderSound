using System.Collections.Generic;
using System.Web;
using ItAcademy.ThunderSound.Client.Models;

namespace ItAcademy.ThunderSound.Client.Services.Interfaces
{
    public interface ISingerPresentationService
    {
        List<SingerViewModel> GetAllSingers();

        List<SingerViewModel> GetSingersByGenreId(int id);

        List<SingerViewModel> GetAllSingersWithGenre();

        SingerViewModel GetOneSingerViewByIdWithGenre(int id);

        void AddSinger(SingerViewModel singerView, HttpPostedFileBase uploadImage);

        byte[] GetImage(int id);

        void DeleteSingerById(int id);

        void EditSinger(SingerViewModel singerView, HttpPostedFileBase uploadImage);

        bool BelongSingerToTheGenre(TrackViewModel track);

        SingerViewModel GetCreateSingerView();
    }
}
