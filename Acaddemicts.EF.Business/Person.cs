using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acaddemicts.EF.Business
{
    public abstract class Person
    {
        public Person()
        {
            Departments = new List<Department>();
        }

        public int PersonId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }        
        public ICollection<Department> Departments { get; set; }
    }
}
