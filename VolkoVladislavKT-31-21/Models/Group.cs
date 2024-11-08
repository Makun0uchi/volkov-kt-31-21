using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace VolkoVladislavKT_31_21.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public bool IsValidGroupName()
        {
            return Regex.Match(GroupName, @"\D*-\d*-\d\d").Success;
        }

        [JsonIgnore]
        public virtual ICollection<Student> Students { get; set; }
    }
}
