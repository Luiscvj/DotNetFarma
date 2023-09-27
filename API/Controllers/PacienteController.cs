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


    [HttpGet("GetAllVentasDeMedicamdnetoPacientePorNombreMedicamento/{NombreMedicamento}")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<MedicamentoPorPacienteH>>> GetAllVentasDeMedicamdnetoPacientePorNombreMedicamento(string NombreMedicamento)
    {
        IEnumerable<MedicamentoPorPacienteH> medicamentoPorPacientes = await _unitOfWork.Pacientes.MedicamentoPacientePorNombreMedicamento(NombreMedicamento);
        if (medicamentoPorPacientes == null) return NotFound();
        return Ok(medicamentoPorPacientes);
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

        [HttpGet("masDineroGastado")]
        // [Authorize(Roles = "Administrador, Gerente")]
        // [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<dynamic>> GetPacienteMasDineroGastado()
        {
            var registros = await _unitOfWork.Pacientes.GetPacienteMasDineroGastado();
            if(registros == null) return NotFound();
            return registros;  
        }
    
    




    
    
    
    
}