using System;
using BestLibraryManagement.ViewModels;
using BestLibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using BestLibraryManagement.Data;

namespace BestLibraryManagement.Controllers
{
    public class CustomersController : Controller
    {
        private readonly BestLibraryManagementDbContext _dbContext;

        public CustomersController(BestLibraryManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var customers = _dbContext.Customers.ToList();
            return View(customers);
        }
    }
}