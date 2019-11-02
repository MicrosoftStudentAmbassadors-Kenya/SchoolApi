using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain 
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  CoordId { get; set; }

        [Required]
        public double Y_Coord { get; set; }

        [Required]
        public double X_Coord { get; set; }

        [Required]
        [StringLength(200,MinimumLength = 2,ErrorMessage = "You must give a Description of the location ie.Location name")]
        public string Description { get; set; }
    }
}
