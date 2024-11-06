namespace VolkoVladislavKT_31_21.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName {  get; set; }


        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
    }
}
