public class ConsultaResponseDto
{
    public int Id { get; set; }
    public int MedicoId { get; set; }
    public string MedicoNome { get; set; }
    public int PacienteId { get; set; }
    public string PacienteNome { get; set; }
    public DateTime DataHora { get; set; }
    public string Status { get; set; }
}
