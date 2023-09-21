using API.Dtos.PaisDto;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using IncApi.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class PaisController : BaseApiController
{
    public PaisController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {

    }


    [HttpPost]
//[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(PaisDto paisDto)
    {
            Pais pais = _mapper.Map<Pais>(paisDto);

            _unitOfWork.Paises.Add(pais);

            int numeroCambios =await  _unitOfWork.SaveAsync();

            if (numeroCambios == 0) return BadRequest();

            return CreatedAtAction(nameof(Add), new {id = pais.PaisId},pais);
    }


    [HttpPost("AddRange")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<PaisDto> paisesDto)
    {
        IEnumerable<Pais> paises = _mapper.Map<IEnumerable<Pais>>(paisesDto);
        _unitOfWork.Paises.AddRange(paises);

        int numeroCambios = await _unitOfWork.SaveAsync();

        if(numeroCambios == 0) return BadRequest();
        foreach(Pais pais in paises)
        {
            CreatedAtAction(nameof(AddRange),new  {id= pais.PaisId},pais);
        }

        return Ok("Registros creados con exito");
    }


    [HttpGet("{id}")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<PaisDto>> GetById(int id)
    {
        Pais pais =await _unitOfWork.Paises.GetById(id);
        return _mapper.Map<PaisDto>(pais);

    }



    [HttpGet("GetAll")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<PaisDto>>> GetAll()
    {
        IEnumerable<Pais> paises = await _unitOfWork.Paises.GetAll();
        var paisesDto= _mapper.Map<IEnumerable<PaisDto>>(paises);
        return Ok(paisesDto);
    }


    [HttpGet("GetAllPage")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

     public async Task<ActionResult<Pager<PaisDepartamentoDto>>> GetChefPaginacion([FromQuery] Params PaisParmas)
        {
            var Pais = await _unitOfWork.Paises.GetAllAsync(PaisParmas.PageIndex,PaisParmas.PageSize,PaisParmas.Search);
            var listPaisesDto =_mapper.Map<List<PaisDepartamentoDto>>(Pais.registros);

            return new Pager<PaisDepartamentoDto>(listPaisesDto, PaisParmas.Search, Pais.totalRegistros, PaisParmas.PageIndex, PaisParmas.PageSize);
        }

    [HttpDelete("{id}")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Delete(int id)
    {
        Pais pais = await _unitOfWork.Paises.GetById(id);
        _unitOfWork.Paises.Remove(pais);
        int numeroCambios = await  _unitOfWork.SaveAsync();
        if(numeroCambios == 0) return BadRequest();
        return Ok("Registro Borrado  con exito");
    }


    [HttpPut]
   // [Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Update(int id, [FromBody]PaisDto paisDto)
    {
        if(paisDto == null) return BadRequest();
        Pais pais =  await _unitOfWork.Paises.GetById(id);
        _mapper.Map(paisDto,pais);
        _unitOfWork.Paises.Update(pais);
        int numeroCambios = await _unitOfWork.SaveAsync();
        if(numeroCambios == 0 ) return BadRequest();
        return Ok("Registro actualizado con exito");
    }
    
    




    
    
    
    
}