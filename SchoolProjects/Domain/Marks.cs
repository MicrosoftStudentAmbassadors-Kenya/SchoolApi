using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
  public class Marks
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int MarkId { get; set; }

            [MaxLength(2)]
            [Required]
            public double MarkValue { get; set; }  
            
            public Student Student { get; set; }
            public Unit Unit { get; set; }
        }
}
