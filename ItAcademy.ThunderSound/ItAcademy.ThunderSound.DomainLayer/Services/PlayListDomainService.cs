using System;
using System.Collections.Generic;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Repositories;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Services;
using ItAcademy.ThunderSound.DomainLayer.Models;
using ItAcademy.ThunderSound.DomainLayer.UnitOfWork;

namespace ItAcademy.ThunderSound.DomainLayer.Services
{
    public class PlayListDomainService : BaseDomainService<PlayListModel>, IPlayListDomainService
    {
        private readonly IPlayListRepository playListRepository;

        public PlayListDomainService(IPlayListRepository playListRepository, IUnitOfWork unitOfWork)
            : base(playListRepository, unitOfWork)
        {
            this.playListRepository = playListRepository;
        }

        public List<PlayListModel> GetTopFivePopularPlayLists()
        {
            throw new NotImplementedException();
        }

        public List<PlayListModel> GetPlayListsBySingerId(int singerId)
        {
            return playListRepository.GetPlayListsBySingerId(singerId);
        }

        public bool BelongPlayListToTheSinger(int playListId, int singerId)
        {
            return playListRepository.BelongPlayListToTheSinger(playListId, singerId);
        }

        public List<PlayListModel> GetAllPlayListsWithSingerandGenreandLabel()
        {
            return playListRepository.GetAllPlayListsWithSingerandGenreandLabel();
        }

        public List<PlayListModel> GetThreePlayListWithLabelandSingerandGenreforMainPage()
        {
            return playListRepository.GetThreePlayListWithLabelandSingerandGenreforMainPage();
        }

        public PlayListModel GetOnePlayListWithSingerandGenreAndLabelByPlayListId(int playListId)
        {
            return playListRepository.GetOnePlayListWithSingerandGenreAndLabelByPlayListId(playListId);
        }
    }
}