using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BestLibraryManagement.Data;
using BestLibraryManagement.Models;
using BestLibraryManagement.ViewModels;

namespace BestLibraryManagement.Controllers
{
    public class BooksController : Controller
    {
        private readonly BestLibraryManagementDbContext _dbContext;

        public BooksController(BestLibraryManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var books = _dbContext.Books.ToList();
            return View(books);
        }
    }
}