using ItAcademy.ThunderSound.DomainLayer.Models.Base;

namespace ItAcademy.ThunderSound.DomainLayer.Models
{
    class TrackLikes : Likes
    {
        public Track Track { get; set; }
    }
}
