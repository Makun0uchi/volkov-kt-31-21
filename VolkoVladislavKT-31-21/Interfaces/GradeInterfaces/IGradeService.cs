using Microsoft.EntityFrameworkCore;
using VolkoVladislavKT_31_21.Database;
using VolkoVladislavKT_31_21.Models;
using VolkoVladislavKT_31_21.Models.Dtos;

namespace VolkoVladislavKT_31_21.Interfaces.GradeInterfaces
{
    public interface IGradeService
    {
        public Task<Grade[]> GetGradesAsync(CancellationToken cancellationToken);
        public Task<Grade[]> GetGradesByStudentIDAsync(int StudentId, CancellationToken cancellationToken);
        public Task<Grade> AddGradeForStudentAsync(int studentId, GradeWithoutStudentIDDto gradeDto, CancellationToken cancellationToken);
        public Task<Grade?> UpdateGradeForStudentAsync(int gradeId, int studentId, GradeWithoutStudentIDDto gradeDto, CancellationToken cancellationToken);
    }

    public class GradeService : IGradeService
    {
        private readonly StudentDbContext _dbContext;

        public GradeService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Grade[]> GetGradesAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<Grade> grades = _dbContext.Set<Grade>();

            return await grades.ToArrayAsync();
        }

        public async Task<Grade[]> GetGradesByStudentIDAsync(int studentId, CancellationToken cancellationToken = default)
        {
            bool studentExist = await _dbContext.Set<Student>().AnyAsync(l => l.StudentId == studentId, cancellationToken);

            if (!studentExist)
                return null;

            IQueryable<Grade> query = _dbContext.Set<Grade>().Where(l => l.StudentId == studentId);

            return await query.ToArrayAsync();
        }

        public async Task<Grade> AddGradeForStudentAsync(int studentId, GradeWithoutStudentIDDto gradeDto, CancellationToken cancellationToken = default)
        {
            var studentExist = await _dbContext.Set<Student>().AnyAsync(l => l.StudentId == studentId, cancellationToken);
            var subjectExist = await _dbContext.Set<Subject>().AnyAsync(l => l.SubjectId == gradeDto.SubjectId, cancellationToken);

            if (!studentExist || !subjectExist)
                return null;

            var grade = new Grade
            {
                StudentId = studentId,
                GradeValue = gradeDto.GradeValue,
                SubjectId = gradeDto.SubjectId
            };

            await _dbContext.Set<Grade>().AddAsync(grade, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return grade;
        }

        public async Task<Grade?> UpdateGradeForStudentAsync(int gradeId, int studentId, GradeWithoutStudentIDDto gradeDto, CancellationToken cancellationToken = default)
        {
            var existingGrade = await _dbContext.Set<Grade>()
                .FirstOrDefaultAsync(l => l.StudentId == studentId && l.GradeId == gradeId, cancellationToken);

            if (existingGrade == null)
                return null;

            var subjectExist = await _dbContext.Set<Subject>().AnyAsync(l => l.SubjectId == gradeDto.SubjectId, cancellationToken);
            if (!subjectExist)
                return null;

            existingGrade.GradeValue = gradeDto.GradeValue;
            existingGrade.SubjectId = gradeDto.SubjectId;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return existingGrade;
        }
    }
}
