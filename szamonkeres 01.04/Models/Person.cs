using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace szamonkeres_01._04.Models
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string FullName { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public int ZipCode { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public DateTime Born { get; set; }
    }
}
