using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System 
{
        public class Student
        {
            [PrimaryKey, AutoIncrement]
            public int StudentId { get; set; }

            [MaxLength(10)]
            [NotNull]
            public long PhoneNumber { get; set; }

            [NotNull]
            public string FirstName { get; set; }

            [NotNull]
            public string LastName { get; set; }

            [MaxLength(2)]
            public int Age { get; set; }

            [MaxLength(8)]
            [NotNull]
            public long NationalId { get; set; }
            public Course Course  { get; set; }
            public Department Department { get; set; }
            public Address Address { get; set; }
            public  string  FullName
            {
                get
                {
                    return $"{FirstName} {LastName}";
                }
            }
        }
}
