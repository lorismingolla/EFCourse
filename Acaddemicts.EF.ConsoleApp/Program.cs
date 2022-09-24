using Acaddemicts.EF.Business;
using Acaddemicts.EF.Model;
using System;
using System.Linq;

namespace Acaddemicts.EF.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Only run once to propagate the DB

            //using (var context = new SchoolContext())
            //{
            //    var dep1 = new Department() { Name = "Direction", StartDate = DateTime.Now };
            //    var dep2 = new Department() { Name = "Cafetaria", StartDate = DateTime.Now };
            //    var dep3 = new Department() { Name = "Teachers Lounge", StartDate = DateTime.Now };
            
            //    context.Departments.Add(dep1);
            //    context.Departments.AddRange(dep2, dep3);
                
            //    context.SaveChanges();
            //}

            using(var context = new SchoolContext())
            {
                var depNames = context.Departments.Select(d => d.Name).ToList();

                depNames.ForEach(depName =>
                {
                    Console.WriteLine(depName);
                });
            }
        }
    }
}
