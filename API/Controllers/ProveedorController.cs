using API.Dtos.ProveedorDto;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class ProveedorController : BaseApiController
{
    public ProveedorController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {

    }


    [HttpPost]
//[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(ProveedorDto ProveedorDto)
    {
        Proveedor Proveedor = _mapper.Map<Proveedor>(ProveedorDto);
        _unitOfWork.Proveedores.Add(Proveedor);
        int numeroCambios =await  _unitOfWork.SaveAsync();
        if (numeroCambios == 0) return BadRequest();
        return CreatedAtAction(nameof(Add), new {id = Proveedor.ProveedorId},Proveedor);
    }


    [HttpPost("AddRange")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<ProveedorDto> ProveedoresDto)
    {
        IEnumerable<Proveedor> Proveedores = _mapper.Map<IEnumerable<Proveedor>>(ProveedoresDto);
        _unitOfWork.Proveedores.AddRange(Proveedores);
        int numeroCambios = await _unitOfWork.SaveAsync();
        if(numeroCambios == 0) return BadRequest();
        foreach(Proveedor Proveedor in Proveedores)
        {
            CreatedAtAction(nameof(AddRange),new  {id= Proveedor.ProveedorId},Proveedor);
        }

        return Ok("Registros creados con exito");
    }


    [HttpGet("{id}")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<ProveedorDto>> GetByIdProveedor(int id)
    {
        Proveedor Proveedor =await _unitOfWork.Proveedores.GetById(id);
        return _mapper.Map<ProveedorDto>(Proveedor);

    }



    [HttpGet("GetAll")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<ProveedorDto>>> GetAll()
    {
        IEnumerable<Proveedor> Proveedores = await _unitOfWork.Proveedores.GetAll();
        var ProveedoresDto= _mapper.Map<IEnumerable<ProveedorDto>>(Proveedores);
        return Ok(ProveedoresDto);
    }

    [HttpGet("ProveedoresMedicamentos50U")]
    //[Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<IEnumerable<ProveedorDto>> ProveedoresMedicamentos50U()
    {
        var Proveedores = await _unitOfWork.Proveedores.ProveedoresMedicamentos50U();
        var proveedordto =_mapper.Map<List<ProveedorDto>>(Proveedores);
        return proveedordto;
    }

    [HttpGet("Proveedores5MedicamentosDiferentes2023")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IEnumerable<ProveedorDto>> GetProveedores5MedicamentosDiferentes2023()
    {
    var proveedores = await _unitOfWork.Proveedores.GetProveedores5MedicamentosDiferentes2023();
    var proveedorDtos = _mapper.Map<List<ProveedorDto>>(proveedores);
    
    return proveedorDtos;
    }

    [HttpGet("GetAllMedicamentosVendidosProveedor")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<ProveedorMedicamentoCompraH>>> GetAllMedicamentosVendidosProveedor()
    {
        IEnumerable<ProveedorMedicamentoCompraH> Proveedores = await _unitOfWork.Proveedores.GetCantidadMedicamentosVendidosProveedor();
   
        return Ok(Proveedores);
    }

    [HttpDelete("{id}")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Delete(int id)
    {
        Proveedor Proveedor = await _unitOfWork.Proveedores.GetById(id);
        _unitOfWork.Proveedores.Remove(Proveedor);
        int numeroCambios = await  _unitOfWork.SaveAsync();
        if(numeroCambios == 0) return BadRequest();
        return Ok("Registro Borrado  con exito");
    }


    [HttpPut]
   // [Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Update(int id, [FromBody]ProveedorDto ProveedorDto)
    {
        if(ProveedorDto == null) return BadRequest();
        Proveedor Proveedor =  await _unitOfWork.Proveedores.GetById(id);
        _mapper.Map(ProveedorDto,Proveedor);
        _unitOfWork.Proveedores.Update(Proveedor);
        int numeroCambios = await _unitOfWork.SaveAsync();
        if(numeroCambios == 0 ) return BadRequest();
        return Ok("Registro actualizado con exito");
    }   
}
    
    
