using AutoMapper;
using MedAgenda.DTOs;
using MedAgenda.Models;

namespace MedAgenda.Profiles;

public class PacienteProfile : Profile
{
    public PacienteProfile()
    {
        CreateMap<PacienteRequestDto, Paciente>();
        CreateMap<Paciente, PacienteResponseDto>();
    }
}
