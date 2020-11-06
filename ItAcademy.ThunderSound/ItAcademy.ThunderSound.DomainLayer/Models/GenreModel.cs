using System.Collections.Generic;

namespace ItAcademy.ThunderSound.DomainLayer.Models
{
    public class GenreModel
    {
        public int GenreId { get; set; }

        public string GenreName { get; set; }

        public byte[] Image { get; set; }

        public List<TrackModel> Tracks { get; set; }

        public List<PlayListModel> PlayLists { get; set; }

        public List<SingerModel> Singers { get; set; }
    }
}