using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedAgenda.Models
{
    public class Consulta
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Medico")]
        public int MedicoId { get; set; }
        [ForeignKey("Paciente")]
        public int PacienteId { get; set; }  
        [Required]
        public DateTime DataHora { get; set; } 
        [Required]
        [RegularExpression("^(pendente|realizada|cancelada)$", ErrorMessage = "Status inválido")]
        public string? Status { get; set; }  
        public Medico? Medico { get; set; }
        public Paciente? Paciente { get; set; }  
    }
}
