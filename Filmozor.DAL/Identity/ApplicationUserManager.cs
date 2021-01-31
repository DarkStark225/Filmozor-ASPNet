using Filmozor.DAL.Entities;
using Microsoft.AspNet.Identity;

namespace Filmozor.DAL.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store)
        {
        }
    }
}
