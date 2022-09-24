using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acaddemicts.EF.Business
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public int AdministratorId { get; set; }
        public virtual Person Administrator { get; set; }
    }
}
