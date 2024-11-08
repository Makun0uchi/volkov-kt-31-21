using System.Text.Json.Serialization;

namespace VolkoVladislavKT_31_21.Models
{
    public class Test
    {
        public int TestId { get; set; }
        public bool isPassed { get; set; }

        public int StudentId { get; set; }
        [JsonIgnore]
        public Student Student { get; set; }
        public int SubjectId { get; set; }
        [JsonIgnore]
        public Subject Subject { get; set; }
    }
}
