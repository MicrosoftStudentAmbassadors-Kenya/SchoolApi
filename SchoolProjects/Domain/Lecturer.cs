using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
  public class Lecturer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LecturerId { get; set; }
        [Required]
        [StringLength(10,ErrorMessage = "The firsname should be less than 10")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(10,ErrorMessage = "Lastname should not exceed 10 value")]
        public string LastName { get; set; }
        [MaxLength(2)] 
        public int Age { get; set; }
        [Required]
        [MaxLength(8)]
        public long NationalId { get; set; }


        public Department Department { get; set; }
        public Address Address { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
