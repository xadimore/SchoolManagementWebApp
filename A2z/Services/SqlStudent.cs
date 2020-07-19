using A2z.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2z.Services
{
    public class SqlStudent : Istudent
    {
        private readonly DatabaseConn db;

        public SqlStudent(DatabaseConn db)
        {
            this.db = db;
        }
        public IEnumerable<Student> GetStudents()
        {
            return db.Students.ToList();
        }
    }
}
