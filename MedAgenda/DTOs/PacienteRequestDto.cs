using System.ComponentModel.DataAnnotations;

namespace MedAgenda.DTOs;

public class PacienteRequestDto
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
    public DateTime DataNascimento { get; set; }

    [Required(ErrorMessage = "O CPF é obrigatório.")]
    public string? CPF { get; set; }

    [Required(ErrorMessage = "O endereço é obrigatório.")]
    [StringLength(200, ErrorMessage = "O endereço não pode ter mais de 200 caracteres.")]
    public string? Endereco { get; set; }

    [Required(ErrorMessage = "O telefone é obrigatório.")]
    [Phone(ErrorMessage = "O telefone informado não tem um formato válido.")]
    public string? Telefone { get; set; }

    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "O e-mail informado não tem um formato válido.")]
    public string? Email { get; set; }
}
