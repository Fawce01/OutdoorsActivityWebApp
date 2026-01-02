using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutdoorsActivityWebApp.Data.Models
{
    public class InstructorReview : Review
    {
        [Required]
        public string InstructorUserId { get; set; }
        [ForeignKey("InstructorUserId")]
        public ApplicationUser Instructor { get; set; }
    }
}
