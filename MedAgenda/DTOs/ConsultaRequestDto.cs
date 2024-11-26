using System.ComponentModel.DataAnnotations;

namespace MedAgenda.DTOs;

public class ConsultaRequestDto
{
    [Required(ErrorMessage = "O campo 'MedicoId' é obrigatório.")]
    [Range(1, int.MaxValue, ErrorMessage = "O campo 'MedicoId' deve ser um valor maior que zero.")]
    public int MedicoId { get; set; }

    [Required(ErrorMessage = "O campo 'PacienteId' é obrigatório.")]
    [Range(1, int.MaxValue, ErrorMessage = "O campo 'PacienteId' deve ser um valor maior que zero.")]
    public int PacienteId { get; set; }

    [Required(ErrorMessage = "O campo 'DataHora' é obrigatório.")]
    [DataType(DataType.DateTime, ErrorMessage = "A data e hora informada é inválida.")]
    public DateTime DataHora { get; set; }

    [Required(ErrorMessage = "O campo 'Status' é obrigatório.")]
    [RegularExpression("^(pendente|realizada|cancelada)$", ErrorMessage = "O status deve ser 'pendente', 'realizada' ou 'cancelada'.")]
    public string? Status { get; set; }
}
