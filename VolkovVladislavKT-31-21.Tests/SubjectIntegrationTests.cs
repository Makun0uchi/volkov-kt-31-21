using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolkoVladislavKT_31_21.Database;
using VolkoVladislavKT_31_21.Interfaces.SubjectInterfaces;
using VolkoVladislavKT_31_21.Models;

namespace VolkovVladislavKT_31_21.Tests
{
    public class SubjectIntegrationTests
    {
        public readonly DbContextOptions<StudentDbContext> _dbContextOptions;

        public SubjectIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<StudentDbContext>()
                .UseInMemoryDatabase(databaseName: "student_db")
                .Options;
        }

        [Fact]
        public async Task GetSubjectsByFilterAsync_TechnicalSubjectIsDeleted_TwoObjects()
        {
            var ctx = new StudentDbContext(_dbContextOptions);
            var subjectService = new SubjectService(ctx);

            var groups = new List<Group>
            {
                new Group
                {
                    GroupName = "KT-31-21"
                },
                new Group
                {
                    GroupName = "KT-41-21"
                }
            };
            await ctx.Set<Group>().AddRangeAsync(groups);

            var students = new List<Student>
            {
                new Student
                {
                    FirstName = "Vladislav",
                    LastName = "Volkov",
                    MiddleName = "Stanislavovich",
                    GroupId = 1,
                },
                new Student
                {
                    FirstName = "Tretyakova",
                    LastName = "Daria",
                    MiddleName = "Vladimirovna",
                    GroupId = 2,
                },
                new Student
                {
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    MiddleName = "Ivanovich",
                    GroupId = 1,
                }
            };
            await ctx.Set<Student>().AddRangeAsync(students);


            var subjects = new List<Subject>
            {
                new Subject
                {
                    SubjectName = "Math",
                    SubjectType = Subject.SubjectNameType.TechnicalSubject,
                    isDeleted = false
                },
                new Subject
                {
                    SubjectName = "Literature",
                    SubjectType = Subject.SubjectNameType.HumanisticSubject,
                    isDeleted = false
                },
                new Subject
                {
                    SubjectName = "Physics",
                    SubjectType = Subject.SubjectNameType.TechnicalSubject,
                    isDeleted = true
                }
            };
            await ctx.Set<Subject>().AddRangeAsync(subjects);

            await ctx.SaveChangesAsync();

            var filter = new VolkoVladislavKT_31_21.Filters.SubjectFilters.SubjectTypeFilter
            {
                SubjectType = Subject.SubjectNameType.TechnicalSubject,
                isDelited = false
            };

            var subjectsResult = await subjectService.GetSubjectsByFilterAsync(filter, CancellationToken.None);

            Assert.Equal(1, subjectsResult.Length);
        }
    }
}
