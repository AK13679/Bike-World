using System.Data.Entity;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BikeWorld.Models
{
    public class BikeDBContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bike> Bike { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        //public DbSet<Genre> Genres { get; set; }

        public BikeDBContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static BikeDBContext Create()
        {
            return new BikeDBContext();
        }
    }
}