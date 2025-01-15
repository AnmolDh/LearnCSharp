using Microsoft.EntityFrameworkCore;
using SMS.Entities;

namespace SMS.Data
{
    public class SMSDbContext(DbContextOptions<SMSDbContext> options) : DbContext(options)
    {
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Enrollment> Enrollments => Set<Enrollment>();

    }
}
