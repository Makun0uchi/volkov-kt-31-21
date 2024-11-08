using System.Text.Json.Serialization;

namespace VolkoVladislavKT_31_21.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Student> Students { get; set; }
    }
}
