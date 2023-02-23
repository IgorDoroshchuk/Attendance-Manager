using System.ComponentModel.DataAnnotations;

namespace Attendance_Tracker.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public int FacultyId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronomic { get; set; }
        public string FullName => $"{Surname} {Name} {Patronomic}";

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public string Degree { get; set; }
        public string ClassLocation { get; set; }

        public Faculty Faculty { get; set; }
    }
}
