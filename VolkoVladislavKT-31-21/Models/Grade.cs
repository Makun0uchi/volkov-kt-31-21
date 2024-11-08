using System.Text.Json.Serialization;

namespace VolkoVladislavKT_31_21.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public int GradeValue { get; set; }

        public int StudentId { get; set; }
        [JsonIgnore]
        public Student Student { get; set; }
        public int SubjectId { get; set; }
        [JsonIgnore]
        public Subject Subject { get; set; }
    }
}
