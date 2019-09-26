using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System 
{
        public class Marks
        {
            [PrimaryKey, AutoIncrement]
            public int MarkId { get; set; }

            [MaxLength(2)]
            [NotNull]
            public double MarkValue { get; set; }   
            public Student Student { get; set; }
            public Unit Unit { get; set; }
        }
}
