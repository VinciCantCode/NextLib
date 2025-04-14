using System.Linq;
using BestLibraryManagement.ViewModels;
using BestLibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using BestLibraryManagement.Data;

namespace BestLibraryManagement.Controllers
{
    public class LibraryBranchesController : Controller
    {
        private readonly BestLibraryManagementDbContext _dbContext;

        public LibraryBranchesController(BestLibraryManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var libraryBranches = _dbContext.Books
                .Select(b => b.LibraryBranchName)
                .Distinct()
                .ToList();
            return View(libraryBranches);
        }
    }
}