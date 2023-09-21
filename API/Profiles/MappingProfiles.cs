
using API.Dtos.CargoDto;
using API.Dtos.CompraDto;
using API.Dtos.EmpleadoDto;
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
        CreateMap<Cargo,CargoDto>().ReverseMap();
        CreateMap<Compra,CompraDto>().ReverseMap();
        CreateMap<Empleado,EmpleadoDto>().ReverseMap();
    }
}
