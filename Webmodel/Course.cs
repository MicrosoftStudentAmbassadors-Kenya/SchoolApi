using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace School_Management_System 
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


            public Department Department { get; set; }
            public Student Student { get; set; }
            public Classroom Classroom { get; set; }
        }
}
