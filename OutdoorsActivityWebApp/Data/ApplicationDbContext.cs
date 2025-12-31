using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OutdoorsActivityWebApp.Data.Models;
using System.Reflection.Emit;

namespace OutdoorsActivityWebApp.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Activity> Activities { get; set; }
    public DbSet<ActivityReview> ActivityReviews { get; set; }
    public DbSet<InstructorReview> InstructorReviews { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<InstructorReview>().HasOne(r => r.Instructor)
            .WithMany()
            .HasForeignKey(r => r.InstructorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<InstructorReview>().HasOne(r => r.Customer)
            .WithMany()
            .HasForeignKey(r => r.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Entity<ActivityReview>()
        .HasIndex(r => new { r.ActivityId, r.CustomerId })
        .IsUnique();

        builder.Entity<InstructorReview>()
            .HasIndex(r => new { r.InstructorId, r.CustomerId })
            .IsUnique();
    }

}
