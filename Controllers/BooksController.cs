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
            // .Include(b => b.Author)  // 加载关联的作者数据
            // .Select(b => new BooksViewModel
            // {
            //     BookId = b.BookId,
            //     Title = b.Title,
            //     Author = b.Author.Name,
            //     LibraryBranchId = b.LibraryBranchId
            // })

            //    //不好的做法 - 加载所有数据到内存
            //    var books = _context.Books.ToList();
            //    var expensiveBooks = books.Where(b => b.Price > 100);

            //    //好的做法 - 在数据库层面筛选
            //    var expensiveBooks = _context.Books
            //        .Where(b => b.Price > 100)
            return View(books);
        }
    }
}