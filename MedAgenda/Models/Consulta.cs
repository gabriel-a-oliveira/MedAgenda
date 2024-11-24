using System.ComponentModel.DataAnnotations;

namespace MedAgenda.Models
{
    public class Consulta
    {
        public int Id { get; set; }
        public int MedicoId { get; set; }
        public int PacienteId { get; set; }  
        [Required]
        public DateTime DataHora { get; set; } 
        [Required]
        [StringLength(20)]
        public string? Status { get; set; }  
        public Medico? Medico { get; set; }
        public Paciente? Paciente { get; set; }  
    }
}
