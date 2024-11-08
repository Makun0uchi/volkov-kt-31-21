using Microsoft.EntityFrameworkCore;
using VolkoVladislavKT_31_21.Database;
using VolkoVladislavKT_31_21.Models;

namespace VolkoVladislavKT_31_21.Interfaces.StudentInterfaces
{
    public interface IStudentService
    {
        public Task<Student[]> GetStudentsAsync(CancellationToken cancellationToken);
        public Task<Student?> GetStudentByIDAsync(int id, CancellationToken cancellationToken);
    }

    public class StudentService : IStudentService
    {
        private readonly StudentDbContext _dbContext;

        public StudentService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Student[]> GetStudentsAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<Student> query = _dbContext.Set<Student>()
                .Include(l => l.Group)
                .Include(l => l.Grades)
                .Include(l => l.Tests);

            return await query.ToArrayAsync();
        }

        public async Task<Student?> GetStudentByIDAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Student>()
                .Include(l => l.Group)
                .Include(l => l.Grades)
                .Include(l => l.Tests)
                .FirstOrDefaultAsync(l => l.StudentId == id);
        }
    }
}
