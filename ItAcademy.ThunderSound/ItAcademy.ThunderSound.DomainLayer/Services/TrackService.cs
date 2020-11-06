using System.Collections.Generic;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Repositories;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Services;
using ItAcademy.ThunderSound.DomainLayer.Models;

namespace ItAcademy.ThunderSound.DomainLayer.Services
{
    public class TrackService : ITrackService
    {
        private readonly ITrackRepository trackRepository;
        public TrackService(ITrackRepository repository)
        {
            this.trackRepository = repository;
        }

        #region CRUD
        public bool AddTrack(Track obj)
        {
            //Validation

            return trackRepository.Add(obj);
        }

        public bool AddTracks(List<Track> obj)
        {
            bool result = false;
            
            foreach(var track in obj)
            {
                //Validation
                result = trackRepository.Add(track);
                
                if (result == false)
                {
                    break;
                }
            }

            return result;
        }

        public bool UpdateTrack(Track obj)
        {
            return false;
        }

        public bool UpdateTracks(List<Track> obj)
        {
            return false;
        }

        public bool DeleteTrack(int id)
        {
            return false;
        }

        public bool DeleteTracks(int[] id)
        {
            return false;
        }
        #endregion

        public List<Track> GetAllTracks()
        {
            return trackRepository.GetAll();
        }

        public List<Track> GetTopFive()
        {
            return null;
        }
    }
}
