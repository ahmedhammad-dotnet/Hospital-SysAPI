using HospitalSysAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalSysAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {

        }
        public DbSet<Doctor>doctors { get; set; }
        public DbSet<Appointment>appointments { get; set; }
        public DbSet<Cart>carts { get; set; }

    }
}
