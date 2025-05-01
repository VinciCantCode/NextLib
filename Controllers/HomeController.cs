using System;
using BestLibraryManagement.ViewModels;
using BestLibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BestLibraryManagement.Data;
using System.Linq;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace BestLibraryManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly BestLibraryManagementDbContext _dbContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(BestLibraryManagementDbContext dbContext, ILogger<HomeController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BorrowBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BorrowBook(BorrowBookViewModel borrowBookViewModel)
        {

            if (!ModelState.IsValid)
            {
                return View(borrowBookViewModel);
            }

            var existingBook = _dbContext.Books.Find(borrowBookViewModel.Title);
            if (existingBook == null)
            {
                var book = new Books
                {
                    Title = borrowBookViewModel.Title,
                    AuthorName = borrowBookViewModel.Author,
                    LibraryBranchName = borrowBookViewModel.LibraryBranchName,
                    CustomerName = borrowBookViewModel.CustomerName,
                    BorrowedAt = DateTime.Now
                };

                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();
            }

            var existingCustomer = _dbContext.Customers.Find(borrowBookViewModel.CustomerName);
            if (existingCustomer == null)
            {
                var customer = new Customers
                {
                    CustomerName = borrowBookViewModel.CustomerName,
                    Email = borrowBookViewModel.Email,
                    PhoneNumber = borrowBookViewModel.PhoneNumber
                };
                _dbContext.Customers.Add(customer);
                _dbContext.SaveChanges();
            }

            var existingAuthor = _dbContext.Authors.Find(borrowBookViewModel.Author);
            if (existingAuthor == null)
            {
                var author = new Authors
                {
                    AuthorName = borrowBookViewModel.Author!
                };
                _dbContext.Authors.Add(author);
                _dbContext.SaveChanges();
            }

            var existingLibraryBranch = _dbContext.LibraryBranches.Find(borrowBookViewModel.LibraryBranchName);
            if (existingLibraryBranch == null)
            {
                var libraryBranch = new LibraryBranches
                {
                    LibraryBranchName = borrowBookViewModel.LibraryBranchName,
                };
                _dbContext.LibraryBranches.Add(libraryBranch);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index", "Books");
        }

        [HttpGet]
        public IActionResult ReturnBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ReturnBook(BorrowBookViewModel borrowBookViewModel)
        {
            var book = _dbContext.Books
                .FirstOrDefault(b => b.Title == borrowBookViewModel.Title);

            if (book == null)
            {
                TempData["ErrorMessage"] = "Book not found.";
                return View(borrowBookViewModel);
            }

            if (book.ReturnedAt != DateTime.MinValue)
            {
                TempData["ErrorMessage"] = "This book has already been returned.";
                return View(borrowBookViewModel);
            }

            if (book.BorrowedAt == DateTime.MinValue)
            {
                TempData["ErrorMessage"] = "This book has not been borrowed yet.";
                return View(borrowBookViewModel);
            }

            book.ReturnedAt = DateTime.Now;
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Books");
        }

        [HttpGet]
        public IActionResult LookupBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LookupBook(BorrowBookViewModel borrowBookViewModel)
        {
            var books = _dbContext.Books
                .Where(b => b.Title.Contains(borrowBookViewModel.Title))
                .ToList();

            ViewBag.SearchResults = books;
            return View(borrowBookViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int? statusCode = null)
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var statusCodeReExecuteFeature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            var errorViewModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                OriginalStatusCode = statusCode ?? 500
            };

            if (statusCodeReExecuteFeature != null)
            {
                var pathBase = statusCodeReExecuteFeature.OriginalPathBase ?? string.Empty;
                var path = statusCodeReExecuteFeature.OriginalPath ?? string.Empty;
                var queryString = statusCodeReExecuteFeature.OriginalQueryString ?? string.Empty;

                errorViewModel.OriginalPathAndQuery = $"{pathBase}{path}{queryString}";
            }
            else if (exceptionHandlerPathFeature != null)
            {
                errorViewModel.OriginalPathAndQuery = exceptionHandlerPathFeature.Path ?? string.Empty;
            }

            if (exceptionHandlerPathFeature?.Error != null)
            {
                errorViewModel.ExceptionMessage = exceptionHandlerPathFeature.Error.Message;
                _logger.LogError(
                    exceptionHandlerPathFeature.Error,
                    "Unhandled exception for request {TraceIdentifier} at path {Path}",
                    errorViewModel.RequestId,
                    exceptionHandlerPathFeature.Path);
            }
            else if (statusCode.HasValue)
            {
                errorViewModel.ExceptionMessage = $"Status code error: {statusCode.Value}";
                _logger.LogWarning(
                    "Status code {StatusCode} for request {TraceIdentifier}",
                    statusCode.Value,
                    errorViewModel.RequestId);
            }

            return View("~/Views/Shared/Error.cshtml", errorViewModel);
        }

    }
}