using System.ComponentModel.DataAnnotations;

namespace VolkoVladislavKT_31_21.Models
{
    public class Subject
    {   
        public enum SubjectType
        {
            [Display(Name = "Гуманитарный")]
            HumanisticSubject,
            [Display(Name = "Технический")]
            TechnicalSubject,
        }

        public int SubjectId { get; set; }
        public SubjectType SubjectName { get; set; }
        public bool isDeleted { get; set; }
    }
}
