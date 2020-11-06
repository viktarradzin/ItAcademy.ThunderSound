using System.Collections.Generic;
using System.Web;
using ItAcademy.ThunderSound.Client.Models;

namespace ItAcademy.ThunderSound.Client.Services.Interfaces
{
    public interface IPlayListPresentationService
    {
        List<PlayListViewModel> GetAllPlayLists();

        List<PlayListViewModel> GetAllPlayListsWithSingerandGenreandLabel();

        List<PlayListViewModel> GetPlayListsBySingerId(int id);

        PlayListViewModel GetCreatePlayListView();

        PlayListViewModel GetPlayListById(int id);

        PlayListViewModel EditPlayList(int id);

        List<PlayListViewModel> GetThreePlayListWithLabelandSingerandGenreforMainPage();

        void EditPlayList(PlayListViewModel genreView, HttpPostedFileBase uploadImage);

        void AddPlayList(PlayListViewModel genreView, HttpPostedFileBase uploadImage);

        void DeletePlayListById(int id);

        byte[] GetImage(int id);

        bool BelongPlayListsToTheSinger(TrackViewModel track);
    }
}