using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Classroom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassId { get; set; }

        [Required]
        [StringLength(10,ErrorMessage = "The classroom name should not exceed 10 characters")]
        public string ClassroomName { get; set; }

        public Address Address { get; set; }
        public Course Course { get; set; }

    }
}
