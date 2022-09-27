using Microsoft.EntityFrameworkCore;
using Acaddemicts.EF.Business;

namespace Acaddemicts.EF.Model
{
    public class SchoolContext: DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SchoolDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
               .HasDiscriminator<bool>("IsEnrolled")
               .HasValue<Instructor>(false)
               .HasValue<Student>(true);

            modelBuilder.Entity<Person>()
                .Property(p => p.FirstName)
                .HasMaxLength(50);

            modelBuilder.Entity<Person>()
                .Property(p => p.LastName)
                .HasMaxLength(50);

            modelBuilder.Entity<Course>()
                .HasDiscriminator<bool>("Online")
                .HasValue<OnSiteCourse>(false)
                .HasValue<OnlineCourse>(true);

            modelBuilder.Entity<CourseGrade>()
                .Property(x => x.Grade)
                .HasColumnType("decimal(3, 2)");

            modelBuilder.Entity<CourseInstructor>()
                .HasKey(ci => new { ci.CourseId, ci.InstructorId });

            modelBuilder.Entity<CourseInstructor>()
                .HasOne(x => x.Course).WithMany(x => x.CourseInstructors)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CourseInstructor>()
                .HasOne(x => x.Instructor).WithMany(x => x.CourseInstructors)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .Property(p => p.Name)
                .HasMaxLength(50);

            modelBuilder.Entity<OnSiteCourse>()
                .Property(p => p.Days)
                .HasMaxLength(50);

            modelBuilder.Entity<OnSiteCourse>()
                .Property(p => p.Location)
                .HasMaxLength(50);

            modelBuilder.Entity<OnlineCourse>()
                .Property(p => p.Url)
                .HasMaxLength(100);

            modelBuilder.Entity<Course>()
                .Property(p => p.Title)
                .HasMaxLength(100);
        }
    }
}
