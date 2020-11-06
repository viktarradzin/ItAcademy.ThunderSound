using System.Collections.Generic;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Repositories;
using ItAcademy.ThunderSound.DomainLayer.Interfaces.Services;
using ItAcademy.ThunderSound.DomainLayer.Models;
using ItAcademy.ThunderSound.DomainLayer.UnitOfWork;

namespace ItAcademy.ThunderSound.DomainLayer.Services
{
    public class TrackDomainService : ITrackDomainService
    {
        private readonly ITrackRepository trackRepository;

        private readonly IUnitOfWork unitOfWork;

        public TrackDomainService(ITrackRepository trackRepository, IUnitOfWork unitOfWork)
        {
            this.trackRepository = trackRepository;

            this.unitOfWork = unitOfWork;
        }

        public void Add(TrackModel obj)
        {
            trackRepository.Add(obj);

            unitOfWork.SaveChanges();
        }

        public void Delete(TrackModel obj)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(int id)
        {
            trackRepository.DeleteById(id);

            unitOfWork.SaveChanges();
        }

        public void Edit()
        {
            unitOfWork.SaveChanges();
        }

        public TrackModel Get(int id)
        {
            return trackRepository.Get(id);
        }

        public List<TrackModel> GetAll()
        {
            return trackRepository.GetAll();
        }

        public List<TrackModel> GetAllTracksWithSingerandGenresAndPlayLists()
        {
            return trackRepository.GetAllTracksWithSingerandGenresAndPlayLists();
        }

        public TrackModel GetOneTracksWithSingerandGenreAndPlayList(int id)
        {
            return trackRepository.GetOneTracksWithSingerandGenreAndPlayList(id);
        }

        public List<TrackModel> GetSixRandomTrackWithPlayListImage()
        {
            return trackRepository.GetSixRandomTrackWithPlayListImage();
        }

        public List<TrackModel> GetTopFivePopularTracks()
        {
            throw new System.NotImplementedException();
        }

        public List<TrackModel> GetTracksWithGenreWithPlayListBySingerId(int singerId)
        {
            return trackRepository.GetTracksWithGenreWithPlayListBySingerId(singerId);
        }

        public List<TrackModel> GetTracksWithGenreWithSingerByPlayListId(int playListId)
        {
            return trackRepository.GetTracksWithGenreWithSingerByPlayListId(playListId);
        }

        public List<TrackModel> GetTracksWithPlayListandSingerByGenreId(int genreId)
        {
            return trackRepository.GetTracksWithPlayListandSingerByGenreId(genreId);
        }

        public void Update(TrackModel obj)
        {
            throw new System.NotImplementedException();
        }
    }
}