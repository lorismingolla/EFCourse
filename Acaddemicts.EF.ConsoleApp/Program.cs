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
                        case '7':
                            Console.WriteLine(input);
                            PrintStudentOrderedWithGrade(ctx);
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
                            PrintNamesEnrolled2004(ctx);
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
            var courses = ctx.Courses.OfType<OnSiteCourse>()
                            .OrderBy(x => x.Title)
                            .Select(x => new { x.Title, x.Location, x.Time, x.Days })
                            .ToList();
            foreach (var course in courses)
            {
                Console.WriteLine(course.Title);
            }
        }

        private static void PrintOnlineCourses(SchoolContext ctx)
        {
            var courseNames = ctx.Courses.OfType<OnlineCourse>()
                            .OrderBy(x => x.Title)
                            .ThenBy(x => x.Url)
                            .Select(x => new { x.Title, x.Url })
                            .ToList();
            foreach (var course in courseNames)
            {
                Console.WriteLine(course);
            }
        }

        private static void PrintStudentDetails(SchoolContext ctx)
        {
            var students = ctx.Persons.OfType<Student>()
                            .OrderBy(x => x.LastName)
                            .Select(x => new { x.LastName, x.FirstName, x.EnrollmentDate.Year })
                            .ToList();
            foreach (var student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
            }
        }

        private static void PrintInstructorDetails(SchoolContext ctx)
        {
            var instructors = ctx.Persons.OfType<Instructor>()
                            .Select(x => new { x.LastName, x.FirstName, Seniority= (DateTime.Now.Year - x.HireDate.Year)})
                            .OrderByDescending(x => x.Seniority)
                            .ToList()
            foreach (var instructor in instructors)
            {
                Console.WriteLine($"{instructor.PersonId}: {instructor.FirstName} {instructor.LastName}");
            }
        }

        private static void PrintStudentsEnrolledPreSeptember04(SchoolContext ctx)
        {
            var students = ctx.Persons.OfType<Student>()
                            .Where(x => x.EnrollmentDate < new DateTime(2004, 9, 1))
                            .Select(x => new { x.LastName, x.FirstName, x.EnrollmentDate})
                            .ToList()
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

        private static void PrintStudentOrderedWithGrade(SchoolContext ctx)
        {
            ctx.Set<CourseGrade>()
                                .OrderBy(x => x.Student.LastName)
                                .ThenBy(x => x.Course.Title)
                                .Where(x => x.Grade.HasValue)
                                .Select(x => $"{x.Student.LastName} {x.Student.FirstName} {x.Course.Title} {x.Grade:0.0}").ToList()
        }

        private static void PrintUniqueInstructorNames(SchoolContext ctx)
        {
            var instructors = ctx.Persons.OfType<Instructor>().Select(x => x.FirstName).Distinct().ToList();
            foreach (string i in instructors)
            {
                Console.WriteLine(i);
            }
        }

        private static void PrintStudentsWithGradesForDepartmentWithBudgetMoreThen200000(SchoolContext ctx)
        {
            var students = ctx.Set<CourseGrade>()
                                .Where(x => x.Student.EnrollmentDate > DateTime.MinValue && x.Grade.HasValue && x.Course.Department.Budget > 200_000)
                                .Select(x => x.StudentId)
                                .Distinct()
                                .Count();
                Console.WriteLine($"{student} students");
        }

        private static void PrintStudentAvgOrderByName(SchoolContext ctx)
        {
            var students = ctx.Persons.OfType<Student>()
                                .OrderBy(x => x.LastName)
                                .ThenBy(x => x.FirstName)
                                .Select(x => $"{x.LastName} {x.FirstName} {x.CourseGrades.Average(y => y.Grade):0.00}").ToList();
            foreach(Student student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} AVG: {student.CourseGrades.Select(x => x.Grade).Average()}");
            }
        }

        private static void PrintLowestGradePerCourse(SchoolContext ctx)
        {
            var courses = ctx.Courses
                                .Where(x => x.CourseGrades.Any(y => y.Grade.HasValue))
                                .Select(x => $"{x.Title} {x.CourseGrades.Min(y => y.Grade):0.00}").ToList()
            foreach (Course course in courses)
            {
                Console.WriteLine($"{course.Title}: {course.CourseGrades.OrderBy(x => x.Grade).First()}");
            }
        }

        private static void PrintHighestGradePerDepartment(SchoolContext ctx)
        {
            var departments = ctx.Departments
                                .Where(x => x.Courses.SelectMany(y => y.CourseGrades).Any(z => z.Grade.HasValue))
                                .Select(x => $"{x.Name} {x.Courses.SelectMany(y => y.CourseGrades).Max(z => z.Grade):0.00}").ToList();
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

        private static void CoursesContainingET(SchoolContext ctx)
        {
            var courses = ctx.Courses
               .Where(x => x.Title.Contains("et"))
               .Select(x => x.Title).ToList
            foreach (var course in courses)
            {
                Console.WriteLine(course.Name);
            }
        }
    }
}
