using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
  public class Course
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CourseId { get; set; }

    [MaxLength(1)]
    public int NumberofYears { get; set; }
    [MaxLength(10)]
    public int NumberofUnits { get; set; }

    [ForeignKey("DepartmentId")]
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    [ForeignKey("StudentId")]
    public Student Student { get; set; }
    [ForeignKey("ClassroomId")]
    public int ClassroomId { get; set; }
    public Classroom Classroom { get; set; }
  }
}
