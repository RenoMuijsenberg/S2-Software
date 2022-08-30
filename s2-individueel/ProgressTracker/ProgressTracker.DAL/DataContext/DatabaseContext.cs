using ProgressTracker.MODEL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataContext
{
    public class DatabaseContext : IdentityDbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<WorkoutModel> Workouts { get; set; }
        public DbSet<ExerciseModel> Exercises { get; set; }
        public DbSet<SetModel> Sets { get; set; }
    }
}