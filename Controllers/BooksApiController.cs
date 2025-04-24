using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BestLibraryManagement.Data;
using BestLibraryManagement.Models;

namespace BestLibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksApiController : ControllerBase
    {
        private readonly BestLibraryManagementDbContext _context;

        public BooksApiController(BestLibraryManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/BooksApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Books>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        // GET: api/BooksApi/5
        [HttpGet("{title}")]
        public async Task<ActionResult<Books>> GetBook(string title)
        {
            var book = await _context.Books.FindAsync(title);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/BooksApi/5
        [HttpPut("{title}")]
        public async Task<IActionResult> PutBook(string title, Books book)
        {
            if (title != book.Title)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(title))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BooksApi
        [HttpPost]
        public async Task<ActionResult<Books>> PostBook(Books book)
        {
            _context.Books.Add(book);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookExists(book.Title))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetBook), new { title = book.Title }, book);
        }

        // DELETE: api/BooksApi/5
        [HttpDelete("{title}")]
        public async Task<IActionResult> DeleteBook(string title)
        {
            var book = await _context.Books.FindAsync(title);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(string title)
        {
            return _context.Books.Any(e => e.Title == title);
        }
    }
}
