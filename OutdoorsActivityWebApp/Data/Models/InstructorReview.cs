using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace OutdoorsActivityWebApp.Data.Models
{
    public class InstructorReview : Review
    {
        public string InstructorId { get; set; }
        public ApplicationUser Instructor { get; set; }
    }
}
