
using API.Dtos.DepartamentoDtos;
using API.Dtos.MedicamentoDtos;
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
        CreateMap<Departamento,DepartamentoDto>().ReverseMap();
        CreateMap<Pais,PaisDepartamentoDto>().ReverseMap();
        CreateMap<Medicamento,MedicamentoDto>().ReverseMap();
    }
}
