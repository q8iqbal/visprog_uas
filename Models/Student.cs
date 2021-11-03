using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusApp.Models
{
    public class Student 
    {
        [Key]
        public int StudentID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [ForeignKey("Departments")]
        public int DepartmentID {get; set;}

        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual Department Department { get; set;}
    }
}