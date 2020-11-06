using ItAcademy.ThunderSound.DomainLayer.Models.Base;

namespace ItAcademy.ThunderSound.DomainLayer.Models
{
    public class SningerLikes : Likes
    {
        public Singer Singer { get; set; }
    }
}
