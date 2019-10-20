using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using School_Management_System;

namespace SchoolApi
{
    public class SchoolDbcontext : DbContext
    {
        /// <inheritdoc />
        public SchoolDbcontext(DbContextOptions<SchoolDbcontext> options) : base(options)
        {

        }

        public virtual DbSet<Classroom> classrooms { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Lecturer> Lecturers { get; set; }
        public virtual DbSet<Marks> Marks { get; set; }
        public virtual DbSet<Student> Students { get; set; }
    }
}
