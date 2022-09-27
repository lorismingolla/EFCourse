using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acaddemicts.EF.Business
{
    public abstract class Course
    {
        public Course()
        {
            CourseInstructors = new List<CourseInstructor>();
        }

        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<CourseInstructor> CourseInstructors { get; set; }
    }
}
