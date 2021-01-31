using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Filmozor.DAL.Entities;

namespace Filmozor.DAL.EF
{
    public class ApplicationContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string conectionString) : base(@"Data Source=.\SQLEXPRESS;Initial Catalog=Filmozor;Integrated Security=True") { }

        public ApplicationContext() : base(@"Data Source=.\SQLEXPRESS;Initial Catalog=Filmozor;Integrated Security=True") { }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
        public DbSet<New> News { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
