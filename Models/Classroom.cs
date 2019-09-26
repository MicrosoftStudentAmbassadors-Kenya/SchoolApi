using SQLite;
using System;
namespace School_Management_System
{
    public class Classroom
    {
        [PrimaryKey, AutoIncrement]
        public int ClassId { get; set; }

        [NotNull]
        public string ClassroomName { get; set; }
        public Address Address { get; set; }
        public Course Course { get; set; }

    }
}
