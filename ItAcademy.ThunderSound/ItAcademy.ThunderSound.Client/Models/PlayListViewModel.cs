using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using ItAcademy.ThunderSound.DomainLayer.Models;

namespace ItAcademy.ThunderSound.Client.Models
{
    public class PlayListViewModel
    {
        public int PlayListId { get; set; }

        public string PlayListName { get; set; }

        public byte[] Image { get; set; }

        public List<TrackModel> Tracks { get; set; }

        public SingerModel Singer { get; set; }

        public GenreModel Genre { get; set; }

        public LabelModel Label { get; set; }

        public IEnumerable<SelectListItem> SelectListSingers { get; set; }

        public IEnumerable<SelectListItem> SelectListGenres { get; set; }

        public IEnumerable<SelectListItem> SelectListLabels { get; set; }

        public HttpPostedFileBase UploadImage { get; set; }
    }
}