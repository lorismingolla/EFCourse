using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acaddemicts.EF.Business
{
    public class OnSiteCourse : Course
    {
        public string Location { get; set; }
        public string Days { get; set; }
        public DateTime Time { get; set; }
    }
}
