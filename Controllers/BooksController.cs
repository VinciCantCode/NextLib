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

        [HttpGet]
        public IActionResult BorrowBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteBook(string title)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Title == title);
            var author = _dbContext.Authors.FirstOrDefault(a => a.AuthorName == book.AuthorName);
            if (book != null)
            {
                _dbContext.Books.Remove(book);
                _dbContext.Authors.Remove(author);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index", "Books");
        }
    }
}