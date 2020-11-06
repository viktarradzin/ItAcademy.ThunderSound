using System.Collections.Generic;
using System.Web.Mvc;
using ItAcademy.ThunderSound.DomainLayer.Models;

namespace ItAcademy.ThunderSound.Client.Models
{
    public class SingerViewModel
    {
        public int SingerId { get; set; }

        public string Name { get; set; }

        public byte[] Image { get; set; }

        public GenreModel Genre { get; set; }

        public List<TrackModel> Tracks { get; set; }

        public List<PlayListModel> PlayLists { get; set; }

        public IEnumerable<SelectListItem> SelectListGenres { get; set; }
    }
}