using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attendance_Tracker.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        [Range(1,360)]
        public int Credit { get; set; }
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
