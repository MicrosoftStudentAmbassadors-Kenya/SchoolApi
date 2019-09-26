using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System 
{
        public class Department
        {
            [PrimaryKey, AutoIncrement]
            public int DepartmentId { get; set; }

            [NotNull]
            public string DepartmentName { get; set; }
            public Course Course { get; set; }
            public Student Student { get; set; }
            public Lecturer Lecturer { get; set; }
            public Address Address { get; set; }
        }
}
