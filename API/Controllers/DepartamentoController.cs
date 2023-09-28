using API.Dtos.DepartamentoDtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class DepartamentoController : BaseApiController
{
    public DepartamentoController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {

    }


    [HttpPost]
//[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(DepartamentoDto DepartamentoDto)
    {
        Departamento Departamento = _mapper.Map<Departamento>(DepartamentoDto);
        _unitOfWork.Departamentos.Add(Departamento);
        int numeroCambios =await  _unitOfWork.SaveAsync();
        if (numeroCambios == 0) return BadRequest();
        return CreatedAtAction(nameof(Add), new {id = Departamento.DepartamentoId},Departamento);
    }


    [HttpPost("AddRange")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<DepartamentoDto> DepartamentosDto)
    {
        IEnumerable<Departamento> Departamentos = _mapper.Map<IEnumerable<Departamento>>(DepartamentosDto);

        _unitOfWork.Departamentos.AddRange(Departamentos);

        int numeroCambios = await _unitOfWork.SaveAsync();

        if(numeroCambios == 0) return BadRequest();

        foreach(Departamento Departamento in Departamentos)
        {
            CreatedAtAction(nameof(AddRange),new  {id= Departamento.DepartamentoId},Departamento);
        }

        return Ok("Registros creados con exito");
    }


    [HttpGet("{id}")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<DepartamentoDto>> GetByIdDepartamento(int id)
    {
        Departamento Departamento =await _unitOfWork.Departamentos.GetById(id);

        return _mapper.Map<DepartamentoDto>(Departamento);

    }

    [HttpGet("GetAll")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<DepartamentoDto>>> GetAll()
    {
        IEnumerable<Departamento> Departamentos = await _unitOfWork.Departamentos.GetAll();
        var DepartamentosDto= _mapper.Map<IEnumerable<DepartamentoDto>>(Departamentos);
        return Ok(DepartamentosDto);
    }

    [HttpDelete("{id}")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Delete(int id)
    {
        Departamento Departamento = await _unitOfWork.Departamentos.GetById(id);

        _unitOfWork.Departamentos.Remove(Departamento);

        int numeroCambios = await  _unitOfWork.SaveAsync();
        if(numeroCambios == 0) return BadRequest();

        return Ok("Registro Borrado  con exito");
    }


    [HttpPut]
   // [Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Update(int id, [FromBody]DepartamentoDto DepartamentoDto)
    {
        if(DepartamentoDto == null) return BadRequest();

        Departamento Departamento =  await _unitOfWork.Departamentos.GetById(id);

        _mapper.Map(DepartamentoDto,Departamento);
        _unitOfWork.Departamentos.Update(Departamento);

        int numeroCambios = await _unitOfWork.SaveAsync();

        if(numeroCambios == 0 ) return BadRequest();
        return Ok("Registro actualizado con exito");
    }
    
}