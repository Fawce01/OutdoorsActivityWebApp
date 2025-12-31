using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static OutdoorsActivityWebApp.Data.Utilities.SD;

namespace OutdoorsActivityWebApp.Data.Models
{
    public class Activity
    {
        public int Id { get; set; }
        [Required]
        public string InstructorUserId { get; set; }
        public ApplicationUser Instructor { get; set; }
        [Required]
        public ActivityType Type { get; set; }
        public string OtherTypeName { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Desc { get; set; }
        public ICollection<ActivityReview> Reviews { get; set; }
    }
}
