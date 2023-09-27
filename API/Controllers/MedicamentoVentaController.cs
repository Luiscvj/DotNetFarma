
using API.Dtos.MedicamentoVentaDtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using IncApi.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class MedicamentoVentaController : BaseApiController
{
    public MedicamentoVentaController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {

    }


    [HttpPost]
//[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(MedicamentoVentaDto MedicamentoVentaDto)
    {
            MedicamentoVenta MedicamentoVenta = _mapper.Map<MedicamentoVenta>(MedicamentoVentaDto);

            _unitOfWork.MedicamentoVentas.Add(MedicamentoVenta);

            int numeroCambios =await  _unitOfWork.SaveAsync();

            if (numeroCambios == 0) return BadRequest();

            return CreatedAtAction(nameof(Add), new {id = MedicamentoVenta.MedicamentoVentaId},MedicamentoVenta);
    }


    [HttpPost("AddRange")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<MedicamentoVentaDto> MedicamentoVentasDto)
    {
        IEnumerable<MedicamentoVenta> MedicamentoVentas = _mapper.Map<IEnumerable<MedicamentoVenta>>(MedicamentoVentasDto);
        _unitOfWork.MedicamentoVentas.AddRange(MedicamentoVentas);

        int numeroCambios = await _unitOfWork.SaveAsync();

        if(numeroCambios == 0) return BadRequest();
        foreach(MedicamentoVenta MedicamentoVenta in MedicamentoVentas)
        {
            CreatedAtAction(nameof(AddRange),new  {id= MedicamentoVenta.MedicamentoVentaId},MedicamentoVenta);
        }

        return Ok("Registros creados con exito");
    }


    [HttpGet("{id}")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<MedicamentoVentaDto>> GetByIdMedicamentoVenta(int id)
    {
        MedicamentoVenta MedicamentoVenta =await _unitOfWork.MedicamentoVentas.GetById(id);
        return _mapper.Map<MedicamentoVentaDto>(MedicamentoVenta);

    }


    [HttpGet("GetDineroRecaudadoVentas")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<decimal>> GetDineroRecaudadoVentas()
    {
        return Ok(_unitOfWork.MedicamentoVentas.GetTotalRecaudadoVentas());

    }

    [HttpGet("GetAll")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<MedicamentoVentaDto>>> GetAll()
    {
        IEnumerable<MedicamentoVenta> MedicamentoVentas = await _unitOfWork.MedicamentoVentas.GetAll();
        IEnumerable<MedicamentoVentaDto> MedicamentoVentasDto= _mapper.Map<IEnumerable<MedicamentoVentaDto>>(MedicamentoVentas);
        return Ok(MedicamentoVentasDto);
    }


/*     [HttpGet("GetAllPage")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

     public async Task<ActionResult<Pager<MedicamentoVentaDepartamentoDto>>> GetChefPaginacion([FromQuery] Params MedicamentoVentaParmas)
        {
            var MedicamentoVenta = await _unitOfWork.MedicamentoVentas.GetAllAsync(MedicamentoVentaParmas.PageIndex,MedicamentoVentaParmas.PageSize,MedicamentoVentaParmas.Search);
            var listMedicamentoVentasDto =_mapper.Map<List<MedicamentoVentaDepartamentoDto>>(MedicamentoVenta.registros);

            return new Pager<MedicamentoVentaDepartamentoDto>(listMedicamentoVentasDto, MedicamentoVentaParmas.Search, MedicamentoVenta.totalRegistros, MedicamentoVentaParmas.PageIndex, MedicamentoVentaParmas.PageSize);
        }
 */
    [HttpDelete("{id}")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Delete(int id)
    {
        MedicamentoVenta MedicamentoVenta = await _unitOfWork.MedicamentoVentas.GetById(id);
        _unitOfWork.MedicamentoVentas.Remove(MedicamentoVenta);
        int numeroCambios = await  _unitOfWork.SaveAsync();
        if(numeroCambios == 0) return BadRequest();
        return Ok("Registro Borrado  con exito");
    }


    [HttpPut]
   // [Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Update(int id, [FromBody]MedicamentoVentaDto MedicamentoVentaDto)
    {
        if(MedicamentoVentaDto == null) return BadRequest();
        MedicamentoVenta MedicamentoVenta =  await _unitOfWork.MedicamentoVentas.GetById(id);
        _mapper.Map(MedicamentoVentaDto,MedicamentoVenta);
        _unitOfWork.MedicamentoVentas.Update(MedicamentoVenta);
        int numeroCambios = await _unitOfWork.SaveAsync();
        if(numeroCambios == 0 ) return BadRequest();
        return Ok("Registro actualizado con exito");
    }
    
    




    
    
    
    
}