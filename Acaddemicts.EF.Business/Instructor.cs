using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acaddemicts.EF.Business
{
    public class Instructor : Person
    {
        public Instructor()
        {
            Departments = new List<Department>();
            CourseInstructors = new List<CourseInstructor>();
        }

        public DateTime HireDate { get; set; }
        public ICollection<Department> Departments { get; set; }
        public ICollection<CourseInstructor> CourseInstructors { get; set; }
    }
}
