using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Unit
    {
        [Key]
        public int UnitId { get; set; }

        [Required]
        public string UnitName { get; set; }
        [StringLength(100,MinimumLength = 10,ErrorMessage = "A unit must have some descriptions")]
        public string Description { get; set; }
        public bool? HasLab { get; set; }

        [MaxLength(100,ErrorMessage = "UnitMark must not be more than 100marks")]
        public double UnitMark { get; set; }
        public Student Student { get; set; }
    }
}
