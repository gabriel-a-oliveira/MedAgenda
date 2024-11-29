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
    [RegularExpression(@"^[A-Za-z0-9\-]{5,20}$", ErrorMessage = "O CRM deve conter apenas letras, números e hífen, com no máximo 20 caracteres.")]
    public string? CRM { get; set; }

    [Required(ErrorMessage = "O telefone é obrigatório.")]
    [Phone(ErrorMessage = "O telefone informado não tem um formato válido.")]
    [RegularExpression(@"^\(?\d{2}\)?\s?\d{5}-\d{4}$", ErrorMessage = "O telefone deve estar no formato (XX) XXXXX-XXXX ou XXXXX-XXXX.")]
    public string? Telefone { get; set; }
}
