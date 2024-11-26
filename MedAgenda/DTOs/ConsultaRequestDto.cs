using System.ComponentModel.DataAnnotations;

public class ConsultaRequestDto
{
    [Required]
    public int MedicoId { get; set; }

    [Required]
    public int PacienteId { get; set; }

    [Required]
    public DateTime DataHora { get; set; }

    [Required]
    [RegularExpression("^(pendente|realizada|cancelada)$", ErrorMessage = "Status inválido")]
    public string? Status { get; set; }
}
