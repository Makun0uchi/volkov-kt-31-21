using VolkoVladislavKT_31_21.Interfaces.GroupInterfaces;
using Microsoft.AspNetCore.Mvc;
using VolkoVladislavKT_31_21.Models.Dtos;

namespace VolkoVladislavKT_31_21.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly ILogger<GroupsController> _logger;
        private readonly IGroupService _groupService;

        public GroupsController(ILogger<GroupsController> logger, IGroupService groupService)
        {
            _logger = logger;
            _groupService = groupService;
        }

        [HttpGet(Name = "GetGroups")]
        public async Task<IActionResult> GetGroupsAsync(CancellationToken cancellationToken = default)
        {
            var groups = await _groupService.GetGroupsAsync(cancellationToken);
            return Ok(groups);
        }

        [HttpGet("{id}", Name = "GetGroupByID")]
        public async Task<IActionResult> GetGroupByIDAsync([FromRoute]int id, CancellationToken cancellationToken = default)
        {
            var group = await _groupService.GetGroupByIDAsync(id, cancellationToken);

            if (group == null)
                return NotFound();
            return Ok(group);
        }

        [HttpPost(Name = "CreateGroup")]
        public async Task<IActionResult> CreateGroupAsync([FromBody]GroupDto groupDto, CancellationToken cancellationToken = default)
        {
            if (groupDto == null)
                return BadRequest();

            var group = await _groupService.CreateGroupAsync(groupDto, cancellationToken);

            return CreatedAtRoute("GetGroupByID", new { id = group.GroupId }, group);
        }

        [HttpPut("{id}", Name = "UpdateGroup")]
        public async Task<IActionResult> UpdateGroupAsync([FromRoute]int id, [FromBody] GroupDto groupDto, CancellationToken cancellationToken = default)
        {
            if (groupDto == null)
                return BadRequest();

            var group = await _groupService.UpdateGroupAsync(id, groupDto, cancellationToken);

            if (group == null)
                return NotFound();
            return Ok(group);
        }

        [HttpDelete("{id}", Name = "DeleteGroup")]
        public async Task<IActionResult> DeleteGroupAsync([FromRoute]int id, CancellationToken cancellationToken = default)
        {
            var group = await _groupService.GetGroupByIDAsync(id, cancellationToken);

            if (group == null)
                return NotFound();

            await _groupService.DeleteGroupAsync(group, cancellationToken);

            return NoContent();
        }
    }
}
