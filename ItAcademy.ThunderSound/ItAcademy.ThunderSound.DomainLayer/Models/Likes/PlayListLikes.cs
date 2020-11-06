using ItAcademy.ThunderSound.DomainLayer.Models.Base;

namespace ItAcademy.ThunderSound.DomainLayer.Models
{
    public class PlayListLikes : Likes
    {
        public PlayList PlayList { get; set; }
    }
}
