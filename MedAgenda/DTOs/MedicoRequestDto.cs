using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace MedAgenda.DTOs;

public class MedicoRequestDto
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "A especialidade é obrigatória.")]
    [StringLength(50, ErrorMessage = "A especialidade não pode ter mais de 50 caracteres.")]
    public string? Especialidade { get; set; }

    [Required(ErrorMessage = "O CRM é obrigatório.")]
    [StringLength(20, ErrorMessage = "O CRM não pode ter mais de 20 caracteres.")]
    public string? CRM { get; set; }

    [Required(ErrorMessage = "O telefone é obrigatório.")]
    [Phone(ErrorMessage = "O telefone informado não tem um formato válido.")]
    public string? Telefone { get; set; }
}
