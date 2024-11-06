using Microsoft.EntityFrameworkCore;
using VolkoVladislavKT_31_21.Models;
using VolkoVladislavKT_31_21.Database.Configurations;

namespace VolkoVladislavKT_31_21.Database
{
    public class StudentDbContext : DbContext
    {
        DbSet<Group> Groups { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Subject> Subjects { get; set; }
        DbSet<Grade> Grades { get; set; }
        DbSet<Test> Tests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new GradeConfiguration());
            modelBuilder.ApplyConfiguration(new TestConfiguration());
        }

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) 
        { 
        }
    }
}
