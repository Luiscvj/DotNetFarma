using System.Globalization;
using API.Dtos.VentaDtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using IncApi.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class VentaController : BaseApiController
{
    public VentaController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {

    }


    [HttpPost]
//[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(VentaDto VentaDto)
    {
            Venta Venta = _mapper.Map<Venta>(VentaDto);

            _unitOfWork.Ventas.Add(Venta);

            int numeroCambios =await  _unitOfWork.SaveAsync();

            if (numeroCambios == 0) return BadRequest();

            return CreatedAtAction(nameof(Add), new {id = Venta.VentaId},Venta);
    }


    [HttpPost("AddRange")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<VentaDto> VentasDto)
    {
        IEnumerable<Venta> Ventas = _mapper.Map<IEnumerable<Venta>>(VentasDto);
        _unitOfWork.Ventas.AddRange(Ventas);

        int numeroCambios = await _unitOfWork.SaveAsync();

        if(numeroCambios == 0) return BadRequest();
        foreach(Venta Venta in Ventas)
        {
            CreatedAtAction(nameof(AddRange),new  {id= Venta.VentaId},Venta);
        }

        return Ok("Registros creados con exito");
    }


    [HttpGet("{id}")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<VentaDto>> GetByIdVenta(int id)
    {
        Venta Venta =await _unitOfWork.Ventas.GetById(id);
        return _mapper.Map<VentaDto>(Venta);

    }



    [HttpGet("GetAll")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<VentaDto>>> GetAll()
    {
        IEnumerable<Venta> Ventas = await _unitOfWork.Ventas.GetAll();
        var VentasDto= _mapper.Map<IEnumerable<VentaDto>>(Ventas);
        return Ok(VentasDto);
    }

    [HttpGet("GetAllVentasDespuesDeEnero")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<VentaDto>>> GetAllVentasDespuesEnero()
    {
        DateTime fechaComparacion = new DateTime(2023,01,01);
        IEnumerable<Venta> Ventas =  _unitOfWork.Ventas.Find(venta => venta.FechaVenta > fechaComparacion);
        var VentasDto= _mapper.Map<IEnumerable<VentaDto>>(Ventas);
        return Ok(VentasDto);
    }

    [HttpGet("GetAllVentasPorMedicamentoNombre/{NombreMedicamento} :string")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<int> > GetAllVentasPorNombreMedicamento(string NombreMedicamento)
    {
        if( NombreMedicamento == String.Empty) return  BadRequest();

        int numeroMedicamentosVendidos= await _unitOfWork.Ventas.GetCountVentasMedicamentoByName(NombreMedicamento);

        if(numeroMedicamentosVendidos == -1) return NotFound("El medicamento indicado no se encuentra registrado");

        return Ok(numeroMedicamentosVendidos);

    }

    [HttpGet("GetAllVentasPorMedicamentoByID/{id} :int")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<int> > GetAllVentasByIdMedicamento(int id)
    {
        int num = await _unitOfWork.MedicamentoVentas.GetAllVentasMedicamentoById(id);

        if(num == 0) return NotFound("No hay ventas registradas para el medicamento");

        return num;

    }


 /*    [HttpGet("GetAllPage")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

     public async Task<ActionResult<Pager<VentaDepartamentoDto>>> GetChefPaginacion([FromQuery] Params VentaParmas)
        {
            var Venta = await _unitOfWork.Ventas.GetAllAsync(VentaParmas.PageIndex,VentaParmas.PageSize,VentaParmas.Search);
            var listVentasDto =_mapper.Map<List<VentaDepartamentoDto>>(Venta.registros);

            return new Pager<VentaDepartamentoDto>(listVentasDto, VentaParmas.Search, Venta.totalRegistros, VentaParmas.PageIndex, VentaParmas.PageSize);
        } */

    [HttpDelete("{id}")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Delete(int id)
    {
        Venta Venta = await _unitOfWork.Ventas.GetById(id);
        _unitOfWork.Ventas.Remove(Venta);
        int numeroCambios = await  _unitOfWork.SaveAsync();
        if(numeroCambios == 0) return BadRequest();
        return Ok("Registro Borrado  con exito");
    }


    [HttpPut]
   // [Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Update(int id, [FromBody]VentaDto VentaDto)
    {
        if(VentaDto == null) return BadRequest();
        Venta Venta =  await _unitOfWork.Ventas.GetById(id);
        _mapper.Map(VentaDto,Venta);
        _unitOfWork.Ventas.Update(Venta);
        int numeroCambios = await _unitOfWork.SaveAsync();
        if(numeroCambios == 0 ) return BadRequest();
        return Ok("Registro actualizado con exito");
    }
    
    




    
    
    
    
}