using VolkoVladislavKT_31_21.Filters.SubjectFilters;
using Microsoft.AspNetCore.Mvc;
using VolkoVladislavKT_31_21.Interfaces.SubjectInterfaces;

namespace VolkoVladislavKT_31_21.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SubjectsController : ControllerBase
    {
        private readonly ILogger<SubjectsController> _logger;
        private readonly ISubjectService _subjectService;

        public SubjectsController(ILogger<SubjectsController> logger, ISubjectService subjectService)
        {
            _logger = logger;
            _subjectService = subjectService;
        }

        [HttpGet(Name = "GetSubjectsByFilter")]
        public async Task<IActionResult> GetSubjectsByFilterAsync([FromQuery]SubjectTypeFilter filter, CancellationToken cancellationToken = default)
        {
            var subjects = await _subjectService.GetSubjectsByFilterAsync(filter, cancellationToken);

            return Ok(subjects);
        }
    }
}
