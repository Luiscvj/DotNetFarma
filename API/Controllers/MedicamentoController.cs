
using API.Dtos.MedicamentoDtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class MedicamentoController : BaseApiController
{
    
    public MedicamentoController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {

    }


    [HttpPost]
//[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(MedicamentoDto MedicamentoDto)
    {
        Medicamento Medicamento = _mapper.Map<Medicamento>(MedicamentoDto);
        _unitOfWork.Medicamentos.Add(Medicamento);
        int numeroCambios =await  _unitOfWork.SaveAsync();
        if (numeroCambios == 0) return BadRequest();
        return CreatedAtAction(nameof(Add), new {id = Medicamento.MedicamentoId},Medicamento);
    }


    [HttpPost("AddRange")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<MedicamentoDto> MedicamentosDto)
    {
        IEnumerable<Medicamento> Medicamentos = _mapper.Map<IEnumerable<Medicamento>>(MedicamentosDto);

        _unitOfWork.Medicamentos.AddRange(Medicamentos);

        int numeroCambios = await _unitOfWork.SaveAsync();

        if(numeroCambios == 0) return BadRequest();

        foreach(Medicamento Medicamento in Medicamentos)
        {
            CreatedAtAction(nameof(AddRange),new  {id= Medicamento.MedicamentoId},Medicamento);
        }

        return Ok("Registros creados con exito");
    }


    [HttpGet("{id}")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<MedicamentoDto>> GetById(int id)
    {
        Medicamento Medicamento =await _unitOfWork.Medicamentos.GetById(id);

        return _mapper.Map<MedicamentoDto>(Medicamento);

    }


    [HttpGet("GetMedicamentosPorProveedorId{id}")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<MedicamentoDto>>>GetMedicamentosPorProveedorId(int id)
    {
        IEnumerable<Medicamento> Medicamento =  _unitOfWork.Medicamentos.Find(x =>x.ProveedorId == id);

        return Ok(_mapper.Map<IEnumerable<MedicamentoDto>>(Medicamento));

    }
    
    


    [HttpGet("GetMedicamentosPorProveedor/{NombreProveedor} :string")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<MedicamentoDto>>> GetAllPorProveedor(string NombreProveedor)
    {
        IEnumerable<Medicamento> Medicamentos = await _unitOfWork.Medicamentos.MedicamentosPorProveedor(NombreProveedor);
        var MedicamentosDto= _mapper.Map<IEnumerable<MedicamentoDto>>(Medicamentos);
        return Ok(MedicamentosDto);
    }


    

    [HttpGet("GetAllMedicamentoInformacionProveedor")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<MedicamentosInfoDto>>> GetAllMedicamentoInformacionProveedor()
    {
        List<MedicamentoInformacionProveedor> medicamentos = await  _unitOfWork.Medicamentos.MedicamentosInformacionProveedores();
        var MedicamentosDto= _mapper.Map<IEnumerable<MedicamentosInfoDto>>(medicamentos);
        return Ok(MedicamentosDto);
    }



    [HttpGet("GetAllMedicamentoMenos50")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<MedicamentoDto>>> GetAllMedicamentoMenos50()
    {
        IEnumerable<Medicamento> Medicamentos = await _unitOfWork.Medicamentos.MedicamentoMas50();
        var MedicamentosDto= _mapper.Map<IEnumerable<MedicamentoDto>>(Medicamentos);
        return Ok(MedicamentosDto);
    }

    [HttpDelete("{id}")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Delete(int id)
    {
        Medicamento Medicamento = await _unitOfWork.Medicamentos.GetById(id);

        _unitOfWork.Medicamentos.Remove(Medicamento);

        int numeroCambios = await  _unitOfWork.SaveAsync();
        if(numeroCambios == 0) return BadRequest();

        return Ok("Registro Borrado  con exito");
    }


    [HttpPut]
   // [Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Update(int id, [FromBody]MedicamentoDto MedicamentoDto)
    {
        if(MedicamentoDto == null) return BadRequest();

        Medicamento Medicamento =  await _unitOfWork.Medicamentos.GetById(id);

        _mapper.Map(MedicamentoDto,Medicamento);
        _unitOfWork.Medicamentos.Update(Medicamento);

        int numeroCambios = await _unitOfWork.SaveAsync();

        if(numeroCambios == 0 ) return BadRequest();
        return Ok("Registro actualizado con exito");
    }
    
    




    
    
    
    
}