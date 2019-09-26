using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System
{
    public class Lecturer
    {
        [PrimaryKey, AutoIncrement]
        public int LecturerId { get; set; }
        [NotNull]
        public string FirstName { get; set; }
        [NotNull]
        public string LastName { get; set; }
        [MaxLength(2)]
        public int Age { get; set; }
        [NotNull]
        [MaxLength(8)]
        public long NationalId { get; set; }
        public Department Department { get; set; }
        public Address Address { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
