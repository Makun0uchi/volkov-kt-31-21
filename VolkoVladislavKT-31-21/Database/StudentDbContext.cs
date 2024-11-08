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

            modelBuilder.Entity<Group>().HasData(
            new Group { GroupId = 1, GroupName = "Group A" },
            new Group { GroupId = 2, GroupName = "Group B" },
            new Group { GroupId = 3, GroupName = "Group C" },
            new Group { GroupId = 4, GroupName = "Group D" },
            new Group { GroupId = 5, GroupName = "Group E" },
            new Group { GroupId = 6, GroupName = "Group F" },
            new Group { GroupId = 7, GroupName = "Group G" },
            new Group { GroupId = 8, GroupName = "Group H" },
            new Group { GroupId = 9, GroupName = "Group I" },
            new Group { GroupId = 10, GroupName = "Group J" }
        );

            // Данные для Subject
            modelBuilder.Entity<Subject>().HasData(
                new Subject { SubjectId = 1, SubjectName = "Mathematics", SubjectType = Subject.SubjectNameType.TechnicalSubject, isDeleted = false },
                new Subject { SubjectId = 2, SubjectName = "Physics", SubjectType = Subject.SubjectNameType.TechnicalSubject, isDeleted = false },
                new Subject { SubjectId = 3, SubjectName = "History", SubjectType = Subject.SubjectNameType.HumanisticSubject, isDeleted = false },
                new Subject { SubjectId = 4, SubjectName = "Biology", SubjectType = Subject.SubjectNameType.TechnicalSubject, isDeleted = false },
                new Subject { SubjectId = 5, SubjectName = "Philosophy", SubjectType = Subject.SubjectNameType.HumanisticSubject, isDeleted = false },
                new Subject { SubjectId = 6, SubjectName = "Chemistry", SubjectType = Subject.SubjectNameType.TechnicalSubject, isDeleted = false },
                new Subject { SubjectId = 7, SubjectName = "Sociology", SubjectType = Subject.SubjectNameType.HumanisticSubject, isDeleted = false },
                new Subject { SubjectId = 8, SubjectName = "Literature", SubjectType = Subject.SubjectNameType.HumanisticSubject, isDeleted = false },
                new Subject { SubjectId = 9, SubjectName = "Computer Science", SubjectType = Subject.SubjectNameType.TechnicalSubject, isDeleted = false },
                new Subject { SubjectId = 10, SubjectName = "Geography", SubjectType = Subject.SubjectNameType.HumanisticSubject, isDeleted = false }
            );

            // Данные для Student
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, FirstName = "Alice", LastName = "Johnson", MiddleName = "M", GroupId = 1 },
                new Student { StudentId = 2, FirstName = "Bob", LastName = "Smith", MiddleName = "A", GroupId = 2 },
                new Student { StudentId = 3, FirstName = "Charlie", LastName = "Brown", MiddleName = "B", GroupId = 1 },
                new Student { StudentId = 4, FirstName = "David", LastName = "Wilson", MiddleName = "C", GroupId = 3 },
                new Student { StudentId = 5, FirstName = "Eve", LastName = "Davis", MiddleName = "D", GroupId = 2 },
                new Student { StudentId = 6, FirstName = "Frank", LastName = "Taylor", MiddleName = "E", GroupId = 3 },
                new Student { StudentId = 7, FirstName = "Grace", LastName = "Evans", MiddleName = "F", GroupId = 4 },
                new Student { StudentId = 8, FirstName = "Hank", LastName = "Moore", MiddleName = "G", GroupId = 5 },
                new Student { StudentId = 9, FirstName = "Ivy", LastName = "Martin", MiddleName = "H", GroupId = 4 },
                new Student { StudentId = 10, FirstName = "Jake", LastName = "White", MiddleName = "I", GroupId = 5 }
            );

            // Данные для Grade
            modelBuilder.Entity<Grade>().HasData(
                new Grade { GradeId = 1, GradeValue = 85, StudentId = 1, SubjectId = 1 },
                new Grade { GradeId = 2, GradeValue = 90, StudentId = 2, SubjectId = 1 },
                new Grade { GradeId = 3, GradeValue = 78, StudentId = 3, SubjectId = 2 },
                new Grade { GradeId = 4, GradeValue = 92, StudentId = 4, SubjectId = 3 },
                new Grade { GradeId = 5, GradeValue = 67, StudentId = 5, SubjectId = 4 },
                new Grade { GradeId = 6, GradeValue = 88, StudentId = 6, SubjectId = 5 },
                new Grade { GradeId = 7, GradeValue = 73, StudentId = 7, SubjectId = 6 },
                new Grade { GradeId = 8, GradeValue = 81, StudentId = 8, SubjectId = 7 },
                new Grade { GradeId = 9, GradeValue = 76, StudentId = 9, SubjectId = 8 },
                new Grade { GradeId = 10, GradeValue = 89, StudentId = 10, SubjectId = 9 }
            );

            // Данные для Test
            modelBuilder.Entity<Test>().HasData(
                new Test { TestId = 1, isPassed = true, StudentId = 1, SubjectId = 1 },
                new Test { TestId = 2, isPassed = false, StudentId = 2, SubjectId = 1 },
                new Test { TestId = 3, isPassed = true, StudentId = 3, SubjectId = 2 },
                new Test { TestId = 4, isPassed = false, StudentId = 4, SubjectId = 3 },
                new Test { TestId = 5, isPassed = true, StudentId = 5, SubjectId = 4 },
                new Test { TestId = 6, isPassed = false, StudentId = 6, SubjectId = 5 },
                new Test { TestId = 7, isPassed = true, StudentId = 7, SubjectId = 6 },
                new Test { TestId = 8, isPassed = false, StudentId = 8, SubjectId = 7 },
                new Test { TestId = 9, isPassed = true, StudentId = 9, SubjectId = 8 },
                new Test { TestId = 10, isPassed = true, StudentId = 10, SubjectId = 9 }
            );
        }

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) 
        { 
        }
    }
}
