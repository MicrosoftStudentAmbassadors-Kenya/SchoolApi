using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
  public class Student
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int StudentId { get; set; }

            [MaxLength(10,ErrorMessage = "Enter a valid Phone Number")]
            [Required]
            [DataType("varchar")]
            public float PhoneNumber { get; set; }

            [Required]
            [MaxLength(20,ErrorMessage = "Firstname must be less than 20 characters")]
            public string FirstName { get; set; }

            [Required] 
            [DataType("Varchar")]
            [MaxLength(20, ErrorMessage = "Lastname must be less than 20 characters")] 
            public string LastName { get; set; }

            [MaxLength(2)]
            [DataType("float")]
            public int Age { get; set; }

            [MaxLength(8)]
            [Required]
            [DataType("varchar")]
            public long NationalId { get; set; }
            public Course Course  { get; set; }
            public Department Department { get; set; }
            public Address Address { get; set; }
            public string FullName => $"{FirstName} {LastName}";
        }
        }

