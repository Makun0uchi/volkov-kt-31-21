using System.ComponentModel.DataAnnotations;

namespace VolkoVladislavKT_31_21.Models
{
    public class Subject
    {   
        public enum SubjectNameType
        {
            [Display(Name = "Гуманитарный")]
            HumanisticSubject,
            [Display(Name = "Технический")]
            TechnicalSubject,
        }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public SubjectNameType SubjectType { get; set; }
        public bool isDeleted { get; set; }
    }
}
