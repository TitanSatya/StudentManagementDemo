using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Domain
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid StudentId { get; set; }
        [Required]
        [MaxLength(50)]
        public string StudentFirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string StudentLastName { get; set; }
        [Required]
        public DateTime StudentDOB { get; set; }
        [MaxLength(300)]
        public string StudentAddress { get; set; }

    }
}
