using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace A2z.Library.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string  Position { get; set; }
        public int Age { get; set; }

        [Required]
        public decimal Salary { get; set; }
    }
}
