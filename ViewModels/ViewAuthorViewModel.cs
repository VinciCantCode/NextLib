using BestLibraryManagement.Models;
using System.Collections.Generic;

namespace BestLibraryManagement.ViewModels
{
    public class ViewAuthorViewModel
    {
        public required List<Books> Books { get; set; }
        public required List<string> Authors { get; set; }
        public required string SelectedAuthor { get; set; }
        public string? PreviousAuthor { get; set; }
        public string? NextAuthor { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
    }
}

