using System.Collections.Generic;

namespace ItAcademy.ThunderSound.DomainLayer.Models
{
    public class SingerModel
    {
        public int SingerId { get; set; }

        public string SingerName { get; set; }

        public byte[] Image { get; set; }

        public List<TrackModel> Tracks { get; set; }

        public List<PlayListModel> PlayLists { get; set; }

        public GenreModel Genre { get; set; }
    }
}