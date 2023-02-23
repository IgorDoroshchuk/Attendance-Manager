namespace Attendance_Tracker.Models
{
    public class Faculty
    {
        public int FacultyId { get; set; }
        public string Name { get;set; }
        public string Location { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
        
    }
}
