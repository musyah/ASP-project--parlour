using Microsoft.EntityFrameworkCore;
using Styleit.Model;

namespace Styleit
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Otps> OtpInfo { get; set; }
    }
}
