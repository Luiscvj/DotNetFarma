
using API.Dtos.CargoDto;
using API.Dtos.CompraDto;
using API.Dtos.Empleado;
using API.Dtos.ArlDto;
using API.Dtos.PacienteDto;
using API.Dtos.PaisDto;
using API.Dtos.ProveedorDto;
using AutoMapper;
using Domain.Entities;
using API.Dtos.MedicamentoDtos;
using API.Dtos.DepartamentoDtos;
using API.Dtos.VentaDtos;
using API.Dtos.MedicamentoCompraDtos;
using API.Dtos.MedicamentoVentaDtos;

namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Medicamento,MedicamentoSoloDto>().ReverseMap();
        CreateMap<Pais,PaisDto>().ReverseMap();
        CreateMap<Paciente,PacienteDto>().ReverseMap();
        CreateMap<Proveedor,ProveedorDto>().ReverseMap();
        CreateMap<Cargo,CargoDto>().ReverseMap();
        CreateMap<Compra,CompraDto>().ReverseMap();
        CreateMap<Compra,CompraProveedorDto>().ReverseMap();
        CreateMap<Empleado,EmpleadoDto>().ReverseMap();
        CreateMap<Departamento,DepartamentoDto>().ReverseMap();
        CreateMap<Pais,PaisDepartamentoDto>().ReverseMap();
        CreateMap<Medicamento,MedicamentoDto>().ReverseMap();
        CreateMap<Medicamento,MedicamentoExpiracionDto>().ReverseMap();
        CreateMap<MedicamentoInformacionProveedorH,MedicamentosInfoDto>().ReverseMap();
        CreateMap<Venta,VentaDto>().ReverseMap();
        CreateMap<MedicamentoCompra,MedicamentoCompraDto>().ReverseMap();
        CreateMap<MedicamentoVenta,MedicamentoVentaDto>().ReverseMap();
      
    }
}
