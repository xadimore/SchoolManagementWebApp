using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace A2z.Library.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Lastname { get; set; }

        
        public DateTime DateofBirth { get; set; }

        
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public string Nationality { get; set; }
        public string Class { get; set; }
        public string Religion { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Telephone { get; set; }
        public string Address { get; set; }

        public ICollection<StudentCourse> studentCourses { get; set; }
    }
}
