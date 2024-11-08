using VolkoVladislavKT_31_21.Database;
using VolkoVladislavKT_31_21.Models;
using Microsoft.EntityFrameworkCore;
using VolkoVladislavKT_31_21.Filters.SubjectFilters;

namespace VolkoVladislavKT_31_21.Interfaces.SubjectInterfaces
{
    public interface ISubjectService
    {
        public Task<Subject[]> GetSubjectsByFilterAsync(SubjectTypeFilter filter, CancellationToken cancellationToken);
    }

    public class SubjectService : ISubjectService 
    {
        private readonly StudentDbContext _dbContext;

        public SubjectService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Subject[]> GetSubjectsByFilterAsync(SubjectTypeFilter filter, CancellationToken cancellationToken = default)
        {
            IQueryable<Subject> query = _dbContext.Set<Subject>();

            if (filter.SubjectType != null)
                query = query.Where(w => w.SubjectType == filter.SubjectType);

            if (filter.isDelited != null)
                query = query.Where(w => w.isDeleted == filter.isDelited);

            return await query.ToArrayAsync();
        }
    }
}
