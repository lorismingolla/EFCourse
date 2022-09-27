using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acaddemicts.EF.Business
{
    public class CourseGrade
    {
        [Key]
        public int EnrollmentId { get; set; }
        public int? CourseId {get; set;}
        public Course Course { get; set; }
        public int? StudentId { get; set; }
        public Student Student { get; set; }
        public decimal? Grade { get; set; }
    }
}
