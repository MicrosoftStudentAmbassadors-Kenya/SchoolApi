using SQLite;

namespace School_Management_System
{
    public class Unit
    {
        [PrimaryKey, AutoIncrement]
        public int UnitId { get; set; }

        [NotNull]
        public string UnitName { get; set; }
        public string Description { get; set; }
        public bool HasLab { get; set; }

        [NotNull]
        public double UnitMark { get; set; }
        public Student Student { get; set; }
    }
}
