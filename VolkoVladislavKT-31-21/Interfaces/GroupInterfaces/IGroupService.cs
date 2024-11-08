using Microsoft.EntityFrameworkCore;
using VolkoVladislavKT_31_21.Database;
using VolkoVladislavKT_31_21.Models;
using VolkoVladislavKT_31_21.Models.Dtos;

namespace VolkoVladislavKT_31_21.Interfaces.GroupInterfaces
{
    public interface IGroupService
    {
        public Task<Group[]> GetGroupsAsync(CancellationToken cancellationToken);
        public Task<Group?> GetGroupByIDAsync(int groupId, CancellationToken cancellationToken);
        public Task<Group> CreateGroupAsync(GroupDto groupDto, CancellationToken cancellationToken);
        public Task<Group?> UpdateGroupAsync(int groupId, GroupDto groupDto, CancellationToken cancellationToken);
        public Task DeleteGroupAsync(Group group, CancellationToken cancellationToken);
    }

    public class GroupService : IGroupService
    {
        private readonly StudentDbContext _dbContext;

        public GroupService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Group[]> GetGroupsAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Group>().ToArrayAsync(cancellationToken);
        }

        public async Task<Group?> GetGroupByIDAsync(int groupId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Group>().FirstOrDefaultAsync(l => l.GroupId == groupId, cancellationToken);
        }

        public async Task<Group> CreateGroupAsync(GroupDto groupDto, CancellationToken cancellationToken = default)
        {
            var group = new Group
            {
                GroupName = groupDto.GroupName
            };

            await _dbContext.Set<Group>().AddAsync(group);
            await _dbContext.SaveChangesAsync();

            return group;
        }

        public async Task<Group?> UpdateGroupAsync(int groupId, GroupDto groupDto, CancellationToken cancellationToken = default)
        {
            var group = await _dbContext.Set<Group>().FindAsync(groupId);

            if (group == null)
                return null;

            group.GroupName = groupDto.GroupName;

            _dbContext.Entry(group).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return group;
        }

        public async Task DeleteGroupAsync(Group group, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<Group>().Remove(group);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
