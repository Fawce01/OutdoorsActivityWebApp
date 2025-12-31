using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace OutdoorsActivityWebApp.Data.Models
{
    public class ActivityReview : Review
    {
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
