using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BestLibraryManagement.Data;
using BestLibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using BestLibraryManagement.ViewModels;

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

        public IActionResult ViewAuthor(string author)
        {
            var books = _dbContext.Books.Where(b => b.AuthorName == author).ToList();
            if (!books.Any())
            {
                return NotFound();
            }

            var allAuthors = _dbContext.Books
                .Select(b => b.AuthorName)
                .Distinct()
                .ToList();
            
            var index = allAuthors.IndexOf(author);

            var viewModel = new ViewAuthorViewModel
            {
               Books = books,
               Authors = allAuthors,
               SelectedAuthor = author,
               PreviousAuthor = index > 0 ? allAuthors[index - 1] : null,
               NextAuthor = index < allAuthors.Count - 1 ? allAuthors[index + 1] : null,
               HasPrevious = index > 0,
               HasNext = index < allAuthors.Count - 1
            };
            return View(viewModel);
        }
    }
} 