using API.Dtos.EpsDto;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class EpsController : BaseApiController
{
    public EpsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {

    }


    [HttpPost]
//[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]

    public async Task<ActionResult> Add(EpsDto EpsDto)
    {
        Console.WriteLine(EpsDto);
        Eps Eps = _mapper.Map<Eps>(EpsDto);
        _unitOfWork.Epses.Add(Eps);
        int numeroCambios =await  _unitOfWork.SaveAsync();
        if (numeroCambios == 0) return BadRequest();
        return CreatedAtAction(nameof(Add), new {id = Eps.EpsId},Eps);
    }


    [HttpPost("AddRange")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<EpsDto> EpsesDto)
    {
        IEnumerable<Eps> Epses = _mapper.Map<IEnumerable<Eps>>(EpsesDto);
        _unitOfWork.Epses.AddRange(Epses);
        int numeroCambios = await _unitOfWork.SaveAsync();
        if(numeroCambios == 0) return BadRequest();
        foreach(Eps Eps in Epses)
        {
            CreatedAtAction(nameof(AddRange),new  {id= Eps.EpsId},Eps);
        }

        return Ok("Registros creados con exito");
    }


    [HttpGet("{id}")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<EpsDto>> GetByIdEps(int id)
    {
        Eps Eps =await _unitOfWork.Epses.GetById(id);
        return _mapper.Map<EpsDto>(Eps);

    }



    [HttpGet("GetAll")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<EpsDto>>> GetAll()
    {
        IEnumerable<Eps> Epses = await _unitOfWork.Epses.GetAll();
        var EpsesDto= _mapper.Map<IEnumerable<EpsDto>>(Epses);
        return Ok(EpsesDto);
    }

    [HttpDelete("{id}")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Delete(int id)
    {
        Eps Eps = await _unitOfWork.Epses.GetById(id);
        _unitOfWork.Epses.Remove(Eps);
        int numeroCambios = await  _unitOfWork.SaveAsync();
        if(numeroCambios == 0) return BadRequest();
        return Ok("Registro Borrado  con exito");
    }


    [HttpPut]
   // [Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Update(int id, [FromBody]EpsDto EpsDto)
    {
        if(EpsDto == null) return BadRequest();
        Eps Eps =  await _unitOfWork.Epses.GetById(id);
        _mapper.Map(EpsDto,Eps);
        _unitOfWork.Epses.Update(Eps);
        int numeroCambios = await _unitOfWork.SaveAsync();
        if(numeroCambios == 0 ) return BadRequest();
        return Ok("Registro actualizado con exito");
    } 
}
    
    
