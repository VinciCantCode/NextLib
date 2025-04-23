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
        
        public BestLibraryManagementDbContext(DbContextOptions<BestLibraryManagementDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // Must call the base method to configure Identity models
            
        }
    }
}