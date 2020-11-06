using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using ItAcademy.ThunderSound.DomainLayer.Models;

namespace ItAcademy.ThunderSound.Client.Models
{
    public class TrackViewModel
    {
        public int TrackId { get; set; }

        public string TrackName { get; set; }

        public string SongText { get; set; }

        public byte[] File { get; set; }

        public GenreModel Genre { get; set; }

        public SingerModel Singer { get; set; }

        public PlayListModel PlayList { get; set; }

        public IEnumerable<SelectListItem> SelectListGenres { get; set; }

        public IEnumerable<SelectListItem> SelectListSingers { get; set; }

        public IEnumerable<SelectListItem> SelectListPlayLists { get; set; }

        public HttpPostedFileBase UploadTrack { get; set; }
    }
}