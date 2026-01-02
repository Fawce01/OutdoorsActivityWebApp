using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OutdoorsActivityWebApp.Data.Models;
using System.Reflection.Emit;

namespace OutdoorsActivityWebApp.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Activity> Activities { get; set; }
    public DbSet<ActivityReview> ActivityReviews { get; set; }
    public DbSet<InstructorReview> InstructorReviews { get; set; }
    public DbSet<Review> Review { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)  // Make sure to pass options to the base class constructor
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Activity>()
            .HasOne(a => a.Instructor)
            .WithMany()
            .HasForeignKey(a => a.InstructorUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<ActivityReview>()
            .HasOne(ar => ar.Activity)
            .WithMany(a => a.Reviews)
            .HasForeignKey(ar => ar.ActivityId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<InstructorReview>()
            .HasOne(ir => ir.Instructor)
            .WithMany()
            .HasForeignKey(ir => ir.InstructorUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Review>()
            .HasOne(r => r.Customer)
            .WithMany()
            .HasForeignKey(r => r.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

