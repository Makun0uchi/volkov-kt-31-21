using VolkoVladislavKT_31_21.Interfaces.GradeInterfaces;
using Microsoft.AspNetCore.Mvc;
using VolkoVladislavKT_31_21.Models.Dtos;

namespace VolkoVladislavKT_31_21.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class GradesController : ControllerBase
    {
        private readonly ILogger<GradesController> _logger;
        private readonly IGradeService _gradeService;

        public GradesController(ILogger<GradesController> logger, IGradeService gradeService)
        {
            _logger = logger;
            _gradeService = gradeService;
        }

        [HttpGet(Name = "GetGrades")]
        public async Task<IActionResult> GetGradesAsync(CancellationToken cancellationToken = default)
        {
            var grades = await _gradeService.GetGradesAsync(cancellationToken);

            return Ok(grades);
        }

        [HttpGet("Student/{studentId}", Name = "GetGradesByStudentID")]
        public async Task<IActionResult> GetGradesByStudentIDAsync([FromRoute]int studentId, CancellationToken cancellationToken = default)
        {
            var grades = await _gradeService.GetGradesByStudentIDAsync(studentId, cancellationToken);

            if (grades == null || !grades.Any())
                return NotFound();
            return Ok(grades);
        }

        [HttpPost("Student/{studentId}", Name = "CreateGradeForStudent")]
        public async Task<IActionResult> AddGradeForStudentAsync([FromRoute]int studentId, [FromBody] GradeWithoutStudentIDDto gradeDto, CancellationToken cancellationToken = default)
        {
            if (gradeDto == null)
                return BadRequest();

            var grade = await _gradeService.AddGradeForStudentAsync(studentId, gradeDto, cancellationToken);

            if (grade == null)
                return NotFound("Student or subject not found.");
            return CreatedAtRoute("GetGradesByStudentID", new { studentId = grade.StudentId, gradeId = grade.GradeId }, grade);
        }

        [HttpPut("{gradeId}/Student/{studentId}", Name = "UpdateGradeForStudent")]
        public async Task<IActionResult> UpdateGradeForStudentAsync([FromRoute]int gradeId, [FromRoute]int studentId, [FromBody]GradeWithoutStudentIDDto gradeDto, CancellationToken cancellationToken = default)
        {
            if (gradeDto == null)
                return BadRequest();

            var result = await _gradeService.UpdateGradeForStudentAsync(gradeId, studentId, gradeDto, cancellationToken);

            if (result == null)
                return NotFound();
            return CreatedAtRoute("GetGradesByStudentID", new { studentId = studentId, gradeId = gradeId }, result);
        }
    }
}
