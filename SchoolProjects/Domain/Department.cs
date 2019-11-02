using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Domain 
{
        public class Department
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int DepartmentId { get; set; }

            [Required]
            public string DepartmentName { get; set; }

            public Course Course { get; set; }
            public Student Student { get; set; }
            public Lecturer Lecturer { get; set; }
            public Address Address { get; set; }
        }
}
