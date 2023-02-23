using System.ComponentModel.DataAnnotations;

namespace Attendance_Tracker.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public int FacultyId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronomic { get; set; }
        public string FullName => $"{Surname} {Name} {Patronomic}";

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Range(1,6)]
        public int StudyingCourse { get; set; }
        public int GroupNumber { get; set; }
        public string Specialty { get; set; }
        //public byte[] ImageData { get; set; }
        //public string ImageMimeType { get; set; }
        public Faculty Faculty { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
