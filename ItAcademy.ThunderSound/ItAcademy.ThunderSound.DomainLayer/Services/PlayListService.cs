using ItAcademy.ThunderSound.DomainLayer.Interfaces.Repositories;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Services;
using ItAcademy.ThunderSound.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItAcademy.ThunderSound.DomainLayer.Services
{
    public class PlayListService : IPlayListService
    {

        private readonly IPlayListRepository playListRepository;
        public PlayListService(IPlayListRepository repository)
        {
            this.playListRepository = repository;
        }

        public bool AddPlayList(PlayList obj)
        {
            return playListRepository.Add(obj);
        }

        public bool AddPlayLists(List<PlayList> obj)
        {
            bool result = true;

            foreach (var playList in obj)
            {
                //Validation
                result = playListRepository.Add(playList);

                if (result == false)
                {
                    break;
                }
            }

            return result;
        }

        public bool DeletePlayList(PlayList obj)
        {
            return playListRepository.Delete(obj);
        }

        public bool DeletePlayLists(List<PlayList> obj)
        {
            bool result = true;

            foreach (var track in obj)
            {
                //Validation
                result = playListRepository.Delete(track);

                if (result == false)
                {
                    break;
                }
            }

            return result;
        }

        public List<PlayList> GetAllPlayLists()
        {
            return playListRepository.GetAll();
        }

        public List<PlayList> GetTopFivePlayLists()
        {
            return playListRepository.GetTopFivePlayLists();
        }

        public bool Update(PlayList obj)
        {
            return playListRepository.Update(obj);
        }

        public bool UpdatePlayLists(List<PlayList> obj)
        {
            bool result = true;

            foreach (var playList in obj)
            {
                //Validation
                result = playListRepository.Update(playList);

                if (result == false)
                {
                    break;
                }
            }

            return result;
        }
    }
}
