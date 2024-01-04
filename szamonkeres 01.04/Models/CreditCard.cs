using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace szamonkeres_01._04.Models
{
    public class CreditCard
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string CardNumber { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string? NameOnCard { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string? Cvv { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]

        public Person Person { get; set; }
        public Guid OwnerId { get; set;}
    }
}
