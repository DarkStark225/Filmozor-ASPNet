using Microsoft.AspNet.Identity.EntityFramework;

namespace Filmozor.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}
