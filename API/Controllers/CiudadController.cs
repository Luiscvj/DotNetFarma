using API.Dtos.CiudadDtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using IncApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CiudadController : BaseApiController
{
    public CiudadController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {

    }


    [HttpPost]
   // [Authorize(Roles="Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(CiudadDto CiudadDto)
    {
            Ciudad Ciudad = _mapper.Map<Ciudad>(CiudadDto);

            _unitOfWork.Ciudades.Add(Ciudad);

            int numeroCambios =await  _unitOfWork.SaveAsync();

            if (numeroCambios == 0) return BadRequest();

            return CreatedAtAction(nameof(Add), new {id = Ciudad.CiudadId},Ciudad);
    }


    [HttpPost("AddRange")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<CiudadDto> CiudadesDto)
    {
        IEnumerable<Ciudad> Ciudades = _mapper.Map<IEnumerable<Ciudad>>(CiudadesDto);
        _unitOfWork.Ciudades.AddRange(Ciudades);

        int numeroCambios = await _unitOfWork.SaveAsync();

        if(numeroCambios == 0) return BadRequest();
        foreach(Ciudad Ciudad in Ciudades)
        {
            CreatedAtAction(nameof(AddRange),new  {id= Ciudad.CiudadId},Ciudad);
        }

        return Ok("Registros creados con exito");
    }


    [HttpGet("{id}")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<CiudadDto>> GetByIdCiudad(int id)
    {
        Ciudad Ciudad =await _unitOfWork.Ciudades.GetById(id);
        return _mapper.Map<CiudadDto>(Ciudad);

    }



    [HttpGet("GetAll")]
   // [Authorize(Roles="Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<CiudadDto>>> GetAll()
    {
        IEnumerable<Ciudad> Ciudades = await _unitOfWork.Ciudades.GetAll();
        var CiudadesDto= _mapper.Map<IEnumerable<CiudadDto>>(Ciudades);
        return Ok(CiudadesDto);
    }


    [HttpGet("GetAllPage")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

     public async Task<ActionResult<Pager<CiudadDto>>> GetChefPaginacion([FromQuery] Params CiudadParmas)
        {
            var Ciudad = await _unitOfWork.Ciudades.GetAllAsync(CiudadParmas.PageIndex,CiudadParmas.PageSize,CiudadParmas.Search);
            var listCiudadesDto =_mapper.Map<List<CiudadDto>>(Ciudad.registros);

            return new Pager<CiudadDto>(listCiudadesDto, CiudadParmas.Search, Ciudad.totalRegistros, CiudadParmas.PageIndex, CiudadParmas.PageSize);
        }

    [HttpDelete("{id}")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Delete(int id)
    {
        Ciudad Ciudad = await _unitOfWork.Ciudades.GetById(id);
        _unitOfWork.Ciudades.Remove(Ciudad);
        int numeroCambios = await  _unitOfWork.SaveAsync();
        if(numeroCambios == 0) return BadRequest();
        return Ok("Registro Borrado  con exito");
    }


    [HttpPut]
   // [Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Update(int id, [FromBody]CiudadDto CiudadDto)
    {
        if(CiudadDto == null) return BadRequest();
        Ciudad Ciudad =  await _unitOfWork.Ciudades.GetById(id);
        _mapper.Map(CiudadDto,Ciudad);
        _unitOfWork.Ciudades.Update(Ciudad);
        int numeroCambios = await _unitOfWork.SaveAsync();
        if(numeroCambios == 0 ) return BadRequest();
        return Ok("Registro actualizado con exito");
    }
    
    




    
    
    
    
}