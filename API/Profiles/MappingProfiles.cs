
using API.Dtos.ArlDto;
using API.Dtos.PacienteDto;
using API.Dtos.PaisDto;
using API.Dtos.ProveedorDto;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Pais,PaisDto>().ReverseMap();
        CreateMap<Paciente,PacienteDto>().ReverseMap();
        CreateMap<Proveedor,ProveedorDto>().ReverseMap();
        CreateMap<Arl, ArlDto>().ReverseMap();
    }
}
