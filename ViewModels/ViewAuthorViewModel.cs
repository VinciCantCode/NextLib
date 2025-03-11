using BestLibraryManagement.Models;
using System.Collections.Generic;

namespace BestLibraryManagement.ViewModels
{
    public class ViewAuthorViewModel
    {
        public List<Books> Books { get; set; }
        public List<string> Authors { get; set; }
        public string SelectedAuthor { get; set; }
        public string PreviousAuthor { get; set; }
        public string NextAuthor { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
    }
}

