using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System 
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
