using System.ComponentModel.DataAnnotations;

namespace MedAgenda.Models
{
    public class Medico
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }
        [Required]
        [StringLength(50)]
        public string? Especialidade { get; set; }
        [Required]
        [StringLength(20)]
        public string? CRM { get; set; }
        [Phone]
        public string? Telefone { get; set; }
    }
}
