using A2z.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2z.Services
{
    public interface Istudent
    {
        IEnumerable<Student> GetStudents();
    }
}
