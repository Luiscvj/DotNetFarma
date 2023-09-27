using API.Dtos.MedicamentoDtos;
using API.Dtos.ProveedorDto;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    [HttpGet("GetMedicamentosPrecioMayorA50YStockMenorA100")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<MedicamentoSoloDto>>> GetMedicamentosPrecioMayorA50YStockMenorA100()
    {
        var medicamentos = await _unitOfWork.Medicamentos.GetMedicamentosPrecioMayorA50YStockMenorA100();
        var MedicamentosDto= _mapper.Map<IEnumerable<MedicamentoSoloDto>>(medicamentos);
        return Ok(MedicamentosDto);
    }

    [HttpGet("NoVendidos")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<MedicamentoSoloDto>>> GetMedicamentosNoVendidos()
    {
        var medicamentos = await _unitOfWork.Medicamentos.MedicamentosNoVendidos();
        var MedicamentosDto= _mapper.Map<IEnumerable<MedicamentoSoloDto>>(medicamentos);
        return Ok(MedicamentosDto);
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
        List<MedicamentoInformacionProveedorH> medicamentos = await  _unitOfWork.Medicamentos.MedicamentosInformacionProveedores();
        var MedicamentosDto= _mapper.Map<IEnumerable<MedicamentosInfoDto>>(medicamentos);
        return Ok(MedicamentosDto);
    }

    [HttpGet("GetTotalMedicamentosVendidosPorMes2023")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Dictionary<int, int>>> GetTotalMedicamentosVendidosPorMes2023()
    {
        var totalMedicamentosPorMes = await _unitOfWork.Medicamentos.GetTotalMedicamentosVendidosPorMes2023();
        return Ok(totalMedicamentosPorMes);
    }


    [HttpGet("TotalMedicamentosVendidosPrimerTrimestre")]
    //[Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<string> TotalMedicamentosVendidosPrimerTrimestre()
    {
        // Obtener el total de medicamentos vendidos en el primer trimestre
        var totalMedicamentos = await _unitOfWork.Medicamentos.TotalMedicamentosVendidosPrimerTrimestre();

        // Agregar el mensaje al resultado
        var mensaje = $"{totalMedicamentos} medicamentos vendidos el primer trimestre.";

        return mensaje;
    }


    [HttpGet("GetMedicamentosVendidosPorMes2023")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Dictionary<int, List<MedicamentoSoloDto>>>> GetMedicamentosVendidosPorMes2023()
    {
        var medicamentosPorMes = await _unitOfWork.Medicamentos.GetMedicamentosVendidosPorMes2023();
        var medicamentosPorMesDto = new Dictionary<int, List<MedicamentoSoloDto>>();

        foreach (var mes in medicamentosPorMes.Keys)
        {
            var medicamentosDto = _mapper.Map<List<MedicamentoSoloDto>>(medicamentosPorMes[mes]);
            medicamentosPorMesDto.Add(mes, medicamentosDto);
        }

        return Ok(medicamentosPorMesDto);
    }


    [HttpGet("GetAllMedicamentoExpiranAntesEnero2024")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<MedicamentoExpiracionDto>>>GetAllMedicamentoExpiranAntesEnero2024()
    {
        DateTime fechaComparacion = new DateTime (2024,01,01);
        IEnumerable<Medicamento> Medicamentos =  _unitOfWork.Medicamentos.Find(medicamento => medicamento.FechaExpiracion < fechaComparacion);
        if (Medicamentos == null) return NoContent();
        var MedicamentosDto= _mapper.Map<IEnumerable<MedicamentoExpiracionDto>>(Medicamentos);
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