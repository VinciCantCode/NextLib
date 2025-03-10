using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;

namespace BestLibraryManagement.Data
{
    public class BestLibraryManagementDbContext : DbContext
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
    }
}