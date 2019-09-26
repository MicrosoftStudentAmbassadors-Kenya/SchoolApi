using SQLite;

namespace School_Management_System
{
    public class Address
    {
        [PrimaryKey, AutoIncrement]
        public int  CoordId { get; set; }

        public double Y_Coord { get; set; }

        public double X_Coord { get; set; }

        public string Description { get; set; }
    }
}
