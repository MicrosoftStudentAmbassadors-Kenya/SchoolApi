using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System 
{
        public class Course
        {
            [PrimaryKey, AutoIncrement]
            public int CourseId { get; set; }

            [MaxLength(1)]
            public int NumberofYears { get; set; }
            public int NumberofUnits { get; set; }
            public Department Department { get; set; }
            public Student Student { get; set; }
            public Classroom Classroom { get; set; }
        }
}
