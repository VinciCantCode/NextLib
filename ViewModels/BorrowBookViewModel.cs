namespace BestLibraryManagement.ViewModels
{
    public class BorrowBookViewModel
    {
        // Book properties
        public required string Title { get; set; }
        public required string Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ReturnedAt { get; set; }

        // Customer properties
        public required string CustomerName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }

        // LibraryBranch properties
        public required string LibraryBranchName { get; set; }
    }
} 