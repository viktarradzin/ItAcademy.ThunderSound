using System.Collections.Generic;
using System.Web;
using ItAcademy.ThunderSound.Client.Models;

namespace ItAcademy.ThunderSound.Client.Services.Interfaces
{
    public interface IGenrePresentationService
    {
        List<GenreViewModel> GetAllGenres();

        GenreViewModel GetGenreById(int id);

        GenreViewModel EditGenre(int id);

        void EditGenre(GenreViewModel genreView);

        void AddGenre(GenreViewModel genreView, HttpPostedFileBase uploadImage);

        void DeleteGenreById(int id);

        bool IsGenreExists(int genreId);

        byte[] GetImage(int id);
    }
}