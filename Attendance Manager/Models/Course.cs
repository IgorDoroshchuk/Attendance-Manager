using System.ComponentModel.DataAnnotations.Schema;

namespace Attendance_Tracker.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
