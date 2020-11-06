using Microsoft.AspNet.Identity.EntityFramework;

namespace ItAcademy.ThunderSound.DomainLayer.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Comments { get; set; }
    }
}
