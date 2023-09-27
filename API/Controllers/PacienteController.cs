using API.Dtos.PacienteDto;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class PacienteController : BaseApiController
{
    public PacienteController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {

    }


    [HttpPost]
//[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(PacienteDto PacienteDto)
    {
        Paciente Paciente = _mapper.Map<Paciente>(PacienteDto);
        _unitOfWork.Pacientes.Add(Paciente);
        int numeroCambios =await  _unitOfWork.SaveAsync();
        if (numeroCambios == 0) return BadRequest();
        return CreatedAtAction(nameof(Add), new {id = Paciente.PacienteId},Paciente);
    }


    [HttpPost("AddRange")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<PacienteDto> PacientesDto)
    {
        IEnumerable<Paciente> Pacientes = _mapper.Map<IEnumerable<Paciente>>(PacientesDto);

        _unitOfWork.Pacientes.AddRange(Pacientes);

        int numeroCambios = await _unitOfWork.SaveAsync();

        if(numeroCambios == 0) return BadRequest();

        foreach(Paciente Paciente in Pacientes)
        {
            CreatedAtAction(nameof(AddRange),new  {id= Paciente.PacienteId},Paciente);
        }

        return Ok("Registros creados con exito");
    }


    [HttpGet("{id}")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<PacienteDto>> GetByIdPaciente(int id)
    {
        Paciente Paciente =await _unitOfWork.Pacientes.GetById(id);

        return _mapper.Map<PacienteDto>(Paciente);

    }

    [HttpGet("PacientesParacetamol")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<PacienteDto>> PacientesParacetamol()
    {
        var paciente = await _unitOfWork.Pacientes.PacientesParacetamol();
        var pacienteDto = _mapper.Map<IEnumerable<PacienteDto>>(paciente);
        // Devuelve el paciente
        return Ok(pacienteDto);
    }

    [HttpGet("TotalGastadoPorPacienteEn2023")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Dictionary<string, decimal>>> TotalGastadoPorPacienteEn2023()
    {
        try
        {
            var totalGastado = await _unitOfWork.Pacientes.TotalGastadoPorPacienteEn2023();
            return Ok(totalGastado);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    

    [HttpGet("GetAll")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<PacienteDto>>> GetAll()
    {
        IEnumerable<Paciente> Pacientes = await _unitOfWork.Pacientes.GetAll();
        var PacientesDto= _mapper.Map<IEnumerable<PacienteDto>>(Pacientes);
        return Ok(PacientesDto);
    }

    [HttpDelete("{id}")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Delete(int id)
    {
        Paciente Paciente = await _unitOfWork.Pacientes.GetById(id);

        _unitOfWork.Pacientes.Remove(Paciente);

        int numeroCambios = await  _unitOfWork.SaveAsync();
        if(numeroCambios == 0) return BadRequest();

        return Ok("Registro Borrado  con exito");
    }


    [HttpPut]
   // [Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Update(int id, [FromBody]PacienteDto PacienteDto)
    {
        if(PacienteDto == null) return BadRequest();

        Paciente Paciente =  await _unitOfWork.Pacientes.GetById(id);

        _mapper.Map(PacienteDto,Paciente);
        _unitOfWork.Pacientes.Update(Paciente);

        int numeroCambios = await _unitOfWork.SaveAsync();

        if(numeroCambios == 0 ) return BadRequest();
        return Ok("Registro actualizado con exito");
    }
    
}