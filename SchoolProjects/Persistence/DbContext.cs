using Domain;
using Microsoft.EntityFrameworkCore;
namespace Persistence
{
  public class SchoolDbContext : DbContext
  {
    public SchoolDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Value> Values { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Lecturer> Lecturers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Unit> Units { get; set; }

    protected override void OnModelCreating(ModelBuilder builder){
      builder.Entity<Value>().HasData(
          new Value { Id = 1, Name = "value 101" },
          new Value { Id = 2, Name = "value 102" },
          new Value { Id = 3, Name = "value 103" }
      );
    }
  }
}