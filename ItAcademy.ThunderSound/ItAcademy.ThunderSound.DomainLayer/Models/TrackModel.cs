namespace ItAcademy.ThunderSound.DomainLayer.Models
{
    public class TrackModel
    {
        public int TrackId { get; set; }

        public string TrackName { get; set; }

        public byte[] File { get; set; }

        public SingerModel Singer { get; set; }

        public GenreModel Genre { get; set; }

        public PlayListModel PlayList { get; set; }
    }
}