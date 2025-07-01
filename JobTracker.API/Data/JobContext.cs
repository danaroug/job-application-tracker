using Microsoft.EntityFrameworkCore;
using JobApplicationTracker.Models;

namespace JobApplicationTracker.Data
{
    // DbContext representing the database session for Job entities
    public class JobContext : DbContext
    {
        // Constructor accepts options (like connection string)
        public JobContext(DbContextOptions<JobContext> options) : base(options) { }

        // DbSet representing the Jobs table in the database
        public DbSet<Job> Jobs { get; set; }
    }
}


