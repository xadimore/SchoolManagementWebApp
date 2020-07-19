using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace A2z.Library.Models
{
    public class StudentCourse
    {
        public int Id { get; set; }

        [DisplayName("Student Name")]
        public int StundentID { get; set; }

        [DisplayName("Course")]
        public string RegistredCourse { get; set; }

        public Student Student { get; set; }

    }
}
