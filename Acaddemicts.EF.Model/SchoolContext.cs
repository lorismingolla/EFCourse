using Microsoft.EntityFrameworkCore;
using Acaddemicts.EF.Business;

namespace Acaddemicts.EF.Model
{
    public class SchoolContext: DbContext
    {
        public DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SchoolDB;Trusted_Connection=True;");
            }
        }
    }
}
