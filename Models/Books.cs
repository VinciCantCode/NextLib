using System;
using System.ComponentModel.DataAnnotations;

namespace BestLibraryManagement.Models
{
    public class Books
    {
        [Key]
        public required string Title { get; set; }
        public string? AuthorName { get; set; }
        public string? LibraryBranchName { get; set; }
        public DateTime BorrowedAt { get; set; }
        public DateTime ReturnedAt { get; set; }
        public string? CustomerName { get; set; }
    }
} 