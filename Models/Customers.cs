using System.ComponentModel.DataAnnotations;

namespace BestLibraryManagement.Models
{
    public class Customers
    {
        [Key]
        public required string CustomerName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
} 