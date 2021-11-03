using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusApp.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentID { get; set; }

        [ForeignKey("Course")]
        public int CourseID { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }

        [Required]
        public string Status { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}

