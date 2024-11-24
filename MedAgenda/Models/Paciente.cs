using System.ComponentModel.DataAnnotations;

namespace MedAgenda.Models
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Nome { get; set; } 

        [Required]
        public DateTime DataNascimento { get; set; }  

        [Required]
        [StringLength(11)]
        public string? CPF { get; set; } 

        [StringLength(255)]
        public string? Endereco { get; set; }

        [Phone]
        public string? Telefone { get; set; } 

        [EmailAddress]
        public string? Email { get; set; }
    }
}
