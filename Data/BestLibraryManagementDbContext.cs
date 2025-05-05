using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BestLibraryManagement.Data
{
    public class BestLibraryManagementDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Models.Books> Books { get; set; }
        public DbSet<Models.Authors> Authors { get; set; }
        public DbSet<Models.Customers> Customers { get; set; }
        public DbSet<Models.LibraryBranches> LibraryBranches { get; set; }
        
        private readonly IConfiguration _configuration;
        
        public BestLibraryManagementDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // Must call the base method to configure Identity models
            
            // You can add other database model configurations here
        }
    }
}