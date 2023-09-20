using API.Dtos.PaisDto;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
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

            _unitOFWork.Paises.Add(pais);

            int numeroCambios =await  _unitOFWork.SaveAsyc();

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

        _unitOFWork.Paises.AddRange(paises);

        int numeroCambios = await _unitOFWork.SaveAsyc();

        if(numeroCambios == 0) return BadRequest();

        foreach(Pais pais in paises)
        {
            CreatedAtAction(nameof(AddRange),new  {id= pais.PaisId},pais);
        }

        return Ok("Registros creados con exito");
    }


    [HttpGet("/{id}")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<PaisDto>> GetById(int id)
    {
        Pais pais =await _unitOFWork.Paises.GetById(id);

        return _mapper.Map<PaisDto>(pais);

    }



    [HttpGet("GetAll")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<PaisDto>>> GetAll()
    {
        IEnumerable<Pais> paises = await _unitOFWork.Paises.GetAll();

      var paisesDto= _mapper.Map<IEnumerable<PaisDto>>(paises);

      return Ok(paisesDto);
    }
    
    
    
    
}