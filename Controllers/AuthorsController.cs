using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BestLibraryManagement.Data;
using BestLibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BestLibraryManagement.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly BestLibraryManagementDbContext _dbContext;

        public AuthorsController(BestLibraryManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var authors = _dbContext.Books
                .Select(b => b.AuthorName)
                .Distinct()
                .ToList();
            return View(authors);
        }
    }
} 