using System.ComponentModel.DataAnnotations;

namespace MedAgenda.DTOs;

public class ConsultaRequestDto
{
    [Required(ErrorMessage = "O campo 'MedicoId' é obrigatório.")]
    public int MedicoId { get; set; }

    [Required(ErrorMessage = "O campo 'PacienteId' é obrigatório.")]
    public int PacienteId { get; set; }

    [Required(ErrorMessage = "O campo 'DataHora' é obrigatório.")]
    public DateTime DataHora { get; set; }

    [Required(ErrorMessage = "O campo 'Status' é obrigatório.")]
    [RegularExpression("^(pendente|realizada|cancelada)$", ErrorMessage = "Status inválido. Use 'pendente', 'realizada' ou 'cancelada'.")]
    public string? Status { get; set; }
}
