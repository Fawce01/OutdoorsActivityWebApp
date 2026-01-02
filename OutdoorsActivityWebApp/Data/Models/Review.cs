using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutdoorsActivityWebApp.Data.Models
{
    public abstract class Review
    {
        public int Id { get; set; }
        [Required]
        public string CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public ApplicationUser Customer { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        [Required]
        [Column(TypeName ="decimal(2, 1)")]
        public double Rating { get; set; } // 1 dp, out of 5
        [Required]
        public bool Anon { get; set; } = false; // User has to have used activity to even leave an anon review
    }
}
