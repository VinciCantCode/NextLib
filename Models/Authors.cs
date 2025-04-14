using System.ComponentModel.DataAnnotations;

namespace BestLibraryManagement.Models
{
    public class Authors
    {
        [Key]
        public required string AuthorName { get; set; }

    }
} 