using System.Collections.Generic;

namespace ItAcademy.ThunderSound.DomainLayer.Models
{
    public class PlayListModel
    {
        public int PlayListId { get; set; }

        public string PlayListName { get; set; }

        public byte[] Image { get; set; }

        public List<TrackModel> Tracks { get; set; }

        public SingerModel Singer { get; set; }

        public GenreModel Genre { get; set; }

        public LabelModel Label { get; set; }
    }
}