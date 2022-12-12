using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ecom.Models;

namespace ecom.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ecom.Models.Product> Product { get; set; }
        public DbSet<ecom.Models.User> User { get; set; }
        public DbSet<ecom.Models.Cart> Cart { get; set; }
    }
}