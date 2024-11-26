using AutoMapper;
using MedAgenda.DTOs;
using MedAgenda.Models;

namespace MedAgenda.Profiles;

public class MedicoProfile: Profile
{
    public MedicoProfile()
    {
        CreateMap<MedicoRequestDto, Medico>();
        CreateMap<Medico, MedicoResponseDto>();
    }
}
