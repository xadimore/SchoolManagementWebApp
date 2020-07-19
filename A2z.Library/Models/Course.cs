using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace A2z.Library.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Subject Name")]
        public string SubjectName { get; set; }
        [DisplayName("Teachers Name")]
        public string TeacherName { get; set; }

    }
}
