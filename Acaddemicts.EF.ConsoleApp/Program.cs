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
            //Only run what you need to propagate the DB

            using (var context = new SchoolContext())
            {
                //    var dep1 = new Department() { Name = "Direction", StartDate = DateTime.Now };
                //    var dep2 = new Department() { Name = "Cafetaria", StartDate = DateTime.Now };
                //    var dep3 = new Department() { Name = "Teachers Lounge", StartDate = DateTime.Now };

                //    context.Departments.Add(dep1);
                //    context.Departments.AddRange(dep2, dep3);

                var person1 = new Person() { LastName = "Sanchez", FirstName = "Rick", HireDate = new DateTime(1970, 2, 1), IsEnrolled = false };
                var person2 = new Person() { LastName = "Simpson", FirstName = "Homer", EnrollmentDate = new DateTime(1980, 2, 1), IsEnrolled = true };
                var person3 = new Person() { LastName = "Marsh", FirstName = "Randy", EnrollmentDate = new DateTime(1990, 2, 1), IsEnrolled = true };
                var person4 = new Person() { LastName = "Belcher", FirstName = "Bob", HireDate = new DateTime(1975, 2, 1), IsEnrolled = false };
                var person5 = new Person() { LastName = "Simpson", FirstName = "Marge", EnrollmentDate = new DateTime(1985, 2, 1), IsEnrolled = true };
                var person6 = new Person() { LastName = "Marsh", FirstName = "Stan", EnrollmentDate = new DateTime(1995, 2, 1), IsEnrolled = true };
                var person7 = new Person() { LastName = "Smith", FirstName = "Mortimer", HireDate = new DateTime(1972, 2, 1), IsEnrolled = false };
                var person8 = new Person() { LastName = "Simpson", FirstName = "Bart", EnrollmentDate = new DateTime(1985, 2, 1), IsEnrolled = true };

                context.Persons.AddRange(person1, person2, person3, person4, person5, person6, person7, person8);

                context.Departments.Add(new Department() { Name = "Gym", StartDate = DateTime.Now, Administrator = new Person() { LastName = "Krupt", FirstName = "Coach", HireDate = DateTime.Now, IsEnrolled = false } });
                context.SaveChanges();
            }

            using (var context = new SchoolContext())
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
