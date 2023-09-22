
using API.Dtos.CargoDto;
using API.Dtos.CompraDto;
using API.Dtos.EmpleadoDto;
using API.Dtos.ArlDto;
using API.Dtos.PacienteDto;
using API.Dtos.PaisDto;
using API.Dtos.ProveedorDto;
using AutoMapper;
using Domain.Entities;
using API.Dtos.MedicamentoDtos;
using API.Dtos.DepartamentoDtos;
using API.Dtos.VentaDtos;

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
        CreateMap<Empleado,EmpleadoDtos>().ReverseMap();
        CreateMap<Departamento,DepartamentoDto>().ReverseMap();
        CreateMap<Pais,PaisDepartamentoDto>().ReverseMap();
        CreateMap<Medicamento,MedicamentoDto>().ReverseMap();
        CreateMap<MedicamentoInformacionProveedor,MedicamentosInfoDto>().ReverseMap();
        CreateMap<Venta,VentaDto>().ReverseMap();
      
    }
}
