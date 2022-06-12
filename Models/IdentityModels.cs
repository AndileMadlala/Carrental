using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace carrentalservice.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarQuote> Quotes { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public System.Data.Entity.DbSet<carrentalservice.Models.GetQuote1> GetQuote1 { get; set; }

        public System.Data.Entity.DbSet<carrentalservice.Models.RegisterViewModel> RegisterViewModels { get; set; }

        public System.Data.Entity.DbSet<carrentalservice.Models.driver> drivers { get; set; }

        public System.Data.Entity.DbSet<carrentalservice.Views.drivers.driverQuote> driverQuotes { get; set; }
    }
}