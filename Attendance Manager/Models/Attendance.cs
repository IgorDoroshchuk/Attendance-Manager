using System.ComponentModel.DataAnnotations;

namespace Attendance_Tracker.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public int EnrollmentID { get; set; }
        public bool Present { get; set; }
        public DateTime AttendanceDate { get; set; }

        [Range(1, 50)]
        public int? Mark { get; set; }

        public Enrollment Enrollment { get; set; }
    }
}
