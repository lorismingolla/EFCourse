using Acaddemicts.EF.Business;
using Acaddemicts.EF.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Acaddemicts.EF.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            while (input != "x")
            {
                input = Console.ReadLine().ToLower();
                using (var ctx = new SchoolContext())
                {
                    switch (input)
                    {
                        case "1":
                            Console.WriteLine(input);
                            PrintOnSiteCourses(ctx);
                            break;
                        case "2":
                            Console.WriteLine(input);
                            PrintOnlineCourses(ctx);
                            break;
                        case "3":
                            Console.WriteLine(input);
                            PrintStudentDetails(ctx);
                            break;
                        case "4":
                            Console.WriteLine(input);
                            PrintInstructorDetails(ctx);
                            break;
                        case "5":
                            PrintStudentsEnrolledPreSeptember04(ctx);
                            Console.WriteLine(input);
                            break;
                        case "6":
                            PrintDepartmentsLessThen3Credits(ctx);
                            Console.WriteLine(input);
                            break;
                        case "8":
                            Console.WriteLine(input);
                            PrintUniqueInstructorNames(ctx);
                            break;
                        case "9":
                            Console.WriteLine(input);
                            PrintStudentsWithGradesForDepartmentWithBudgetMoreThen200000(ctx);
                            break;
                        case "10":
                            Console.WriteLine(input);
                            PrintStudentAvgOrderByName(ctx);
                            break;
                        case "11":
                            Console.WriteLine(input);
                            PrintLowestGradePerCourse(ctx);
                            break;
                        case "12":
                            Console.WriteLine(input);
                            PrintHighestGradePerDepartment(ctx);
                            break;
                        case "13":
                            Console.WriteLine(input);
                            PrintStudentAvgOrderByName(ctx);
                            break;
                        case "14":
                            Console.WriteLine(input);
                            PrintNamesEnrolled2004(ctx);
                            break;
                        case "x":
                            break;
                    }
                }
            }
        }

        private static void PrintOnSiteCourses(SchoolContext ctx)
        {
            var courses = ctx.Courses.OfType<OnSiteCourse>().ToArray();
            foreach (OnSiteCourse course in courses)
            {
                Console.WriteLine(course.Title);
            }
        }

        private static void PrintOnlineCourses(SchoolContext ctx)
        {
            var courseNames = ctx.Courses.OfType<OnlineCourse>().Select(x => x.Title).ToArray();
            foreach (string course in courseNames)
            {
                Console.WriteLine(course);
            }
        }

        private static void PrintStudentDetails(SchoolContext ctx)
        {
            var students = ctx.Persons.OfType<Student>().ToArray();
            foreach (Student student in students)
            {
                Console.WriteLine($"{student.PersonId}: {student.FirstName} {student.LastName}");
            }
        }

        private static void PrintInstructorDetails(SchoolContext ctx)
        {
            var instructors = ctx.Persons.OfType<Instructor>().ToArray();
            foreach (Instructor instructor in instructors)
            {
                Console.WriteLine($"{instructor.PersonId}: {instructor.FirstName} {instructor.LastName}");
            }
        }

        private static void PrintStudentsEnrolledPreSeptember04(SchoolContext ctx)
        {
            var students = ctx.Persons.OfType<Student>().Where(x => x.EnrollmentDate < new DateTime(2004, 9, 1)).ToArray();
            foreach (Student student in students)
            {
                Console.WriteLine($"{student.FirstName}, {student.LastName}");
            }
        }

        private static void PrintDepartmentsLessThen3Credits(SchoolContext ctx)
        {
            var departments = ctx.Departments.Where(x => x.Courses.Select(x => x.Credits).Average() < 3).Include(departments => departments.Courses).ToArray();
            foreach (Department department in departments)
            {
                Console.WriteLine($"{department.Name}");
            }
        }


        private static void PrintUniqueInstructorNames(SchoolContext ctx)
        {
            var instructors = ctx.Persons.OfType<Instructor>().Select(x => x.FirstName).Distinct().ToArray();
            foreach (string i in instructors)
            {
                Console.WriteLine(i);
            }
        }

        private static void PrintStudentsWithGradesForDepartmentWithBudgetMoreThen200000(SchoolContext ctx)
        {
            var students = ctx.Persons.OfType<Student>().Where(x => x.CourseGrades.Any(y => y.Course.Department.Budget > 200000)).ToArray();
            foreach (Student student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
            }
        }

        private static void PrintStudentAvgOrderByName(SchoolContext ctx)
        {
            var students = ctx.Persons.OfType<Student>().OrderBy(x => x.FirstName);
            foreach(Student student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} AVG: {student.CourseGrades.Select(x => x.Grade).Average()}");
            }
        }

        private static void PrintLowestGradePerCourse(SchoolContext ctx)
        {
            var courses = ctx.Courses.ToArray();
            foreach (Course course in courses)
            {
                Console.WriteLine($"{course.Title}: {course.CourseGrades.OrderBy(x => x.Grade).First()}");
            }
        }

        private static void PrintHighestGradePerDepartment(SchoolContext ctx)
        {
            var departments = ctx.Departments.ToArray();
            foreach (var department in departments)
            {
                Console.WriteLine($"{department.Name}: {department.Courses.OrderBy(x => x.CourseGrades.Select(x => x.Grade))}");
            }
        }

        private static void PrintNamesEnrolled2004(SchoolContext ctx)
        {
            var students = ctx.Persons.OfType<Student>().Where(x => x.EnrollmentDate > new DateTime(2004,1,1)).ToArray();
            foreach (var student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
            }
        }
    }
}
