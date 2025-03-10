namespace BestLibraryManagement.ViewModels
{
    public class BooksViewModel
    {
        public int BookId { get; set; }
        public required string Title { get; set; }
        public string? Author { get; set; }
        public string? CustomerName { get; set; }
        public string? LibraryBranchName { get; set; }
    }
}