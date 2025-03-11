using System.ComponentModel.DataAnnotations;

namespace BestLibraryManagement.Models
{
    public class LibraryBranches
    {
        [Key]
        public required string LibraryBranchName { get; set; }
    }
}