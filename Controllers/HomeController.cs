using System;
using BestLibraryManagement.ViewModels;
using BestLibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BestLibraryManagement.Data;

namespace BestLibraryManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly BestLibraryManagementDbContext _dbContext;

        public HomeController(BestLibraryManagementDbContext dbContext)
        {
            _dbContext = dbContext;
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

            var libraryBranch = new LibraryBranches
            {
                LibraryBranchName = borrowBookViewModel.LibraryBranchName,
            };
            _dbContext.LibraryBranches.Add(libraryBranch);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}