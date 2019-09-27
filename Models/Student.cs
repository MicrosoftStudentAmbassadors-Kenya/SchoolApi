using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System 
{
        public class Student
        {
            [Key]
            public int StudentId { get; set; }

            [MaxLength(10,ErrorMessage = "Enter a valid Phone Number")]
            [Required]
            public long PhoneNumber { get; set; }

            [Required]
            public string FirstName { get; set; }

            [Required]
            public string LastName { get; set; }

            [MaxLength(2)]
            public int Age { get; set; }

            [MaxLength(8)]
            [Required]
            public long NationalId { get; set; }
            public Course Course  { get; set; }
            public Department Department { get; set; }
            public Address Address { get; set; }
            public string FullName => $"{FirstName} {LastName}";
        }
        }

