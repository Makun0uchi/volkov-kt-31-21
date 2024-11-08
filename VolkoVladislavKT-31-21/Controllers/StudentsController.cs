using Microsoft.AspNetCore.Mvc;
using VolkoVladislavKT_31_21.Interfaces.StudentInterfaces;

namespace VolkoVladislavKT_31_21.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly IStudentService _studentService;

        public StudentsController(ILogger<StudentsController> logger, IStudentService subjectService)
        {
            _logger = logger;
            _studentService = subjectService;
        }

        [HttpGet(Name = "GetStudents")]
        public async Task<IActionResult> GetStudentsAsync(CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetStudentsAsync(cancellationToken);

            return Ok(students);
        }

        [HttpGet("{id}", Name = "GetStudentByID")]
        public async Task<IActionResult> GetStudentByIDAsync([FromRoute]int id, CancellationToken cancellationToken = default)
        {
            return Ok(await _studentService.GetStudentByIDAsync(id, cancellationToken));
        }
    }   
}
