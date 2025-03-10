using System.ComponentModel.DataAnnotations;

namespace BestLibraryManagement.Models
{
    public class LibraryBranches
    {
        [Key]
        public int LibraryBranchId { get; set; }
        public required string LibraryBranchName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
    }
} 