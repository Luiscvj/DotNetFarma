using API.Dtos.EmpleadoDto;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using IncApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
// Empleado, empleado, Empleados, empleados
public class EmpleadoController : BaseApiController
{
    public EmpleadoController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    
    }
   /* [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<Empleado>>> Get()
    {
        var regiones = await _unitOfWork.Empleados.GetAllAsync();
        return Ok(regiones);
    }*/
    [HttpGet]
    [Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<EmpleadoDtos>>> Get()
    {
        var empleados = await _unitOfWork.Empleados.GetAll();
        return _mapper.Map<List<EmpleadoDtos>>(empleados);
    }
    [HttpGet("Pager")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<EmpleadoDtos>>> Get11([FromQuery] Params empleadoParams)
    {
        var empleado = await _unitOfWork.Empleados.GetAllAsync(empleadoParams.PageIndex,empleadoParams.PageSize,empleadoParams.Search);
        var lstEmpleadosDto = _mapper.Map<List<EmpleadoDtos>>(empleado.registros);
        return new Pager<EmpleadoDtos>(lstEmpleadosDto,empleadoParams.Search,empleado.totalRegistros,empleadoParams.PageIndex,empleadoParams.PageSize);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EmpleadoDtos>> Get(int id)
    {
        var empleado = await _unitOfWork.Empleados.GetById(id);
        if (empleado == null){
            return NotFound();
        }
        return _mapper.Map<EmpleadoDtos>(empleado);
    }
    /*[HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Empleado>> Post(Empleado empleado){
        this._unitOfWork.Empleados.Add(empleado);
        await _unitOfWork.SaveAsync();
        if (empleado == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= empleado.Id}, empleado);
    }*/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Empleado>> Post(EmpleadoDtos EmpleadoDtos){
        var empleado = _mapper.Map<Empleado>(EmpleadoDtos);
        this._unitOfWork.Empleados.Add(empleado);
        await _unitOfWork.SaveAsync();
        if (empleado == null)
        {
            return BadRequest();
        }
        EmpleadoDtos.EmpleadoId = empleado.EmpleadoId;
        return CreatedAtAction(nameof(Post),new {id= EmpleadoDtos.EmpleadoId}, EmpleadoDtos);
    }
    /*[HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Put(int id, [FromBody]Area empleado){
        if(empleado == null)
            return NotFound();
        _unitOfWork.Empleados.Update(empleado);
        await _unitOfWork.SaveAsync();
        return empleado;
        
    }*/
    [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update(int id , [FromBody]EmpleadoDtos EmpleadoDtos)
        {
            if(EmpleadoDtos == null)
                return BadRequest();

            Empleado Empleado = await _unitOfWork.Empleados.GetById(id);

            _mapper.Map(EmpleadoDtos, Empleado);
            _unitOfWork.Empleados.Update(Empleado);

            int num = await _unitOfWork.SaveAsync();

            if(num == 0)
                return BadRequest();

            return Ok("REGISTRO ACTUALIZADO CON EXITO");
        }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var empleado = await _unitOfWork.Empleados.GetById(id);
        if(empleado == null){
            return NotFound();
        }
        _unitOfWork.Empleados.Remove(empleado);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}