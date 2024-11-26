using AutoMapper;
using MedAgenda.DTOs;
using MedAgenda.Models;

namespace MedAgenda.Profiles;

public class ConsultaProfile : Profile
{
    public ConsultaProfile()
    {
        CreateMap<Consulta, ConsultaResponseDto>();
        CreateMap<ConsultaRequestDto, Consulta>();
        CreateMap<Medico, MedicoResponseDto>();
        CreateMap<Paciente, PacienteResponseDto>();
    }
}
