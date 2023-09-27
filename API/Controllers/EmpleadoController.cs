using API.Dtos.EmpleadoDtos;
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
    //[Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<EmpleadoDto>>> Get()
    {
        var empleados = await _unitOfWork.Empleados.GetAll();
        return _mapper.Map<List<EmpleadoDto>>(empleados);
    }


   

    [HttpGet("Pager")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<EmpleadoDto>>> Get11([FromQuery] Params empleadoParams)
    {
        var empleado = await _unitOfWork.Empleados.GetAllAsync(empleadoParams.PageIndex,empleadoParams.PageSize,empleadoParams.Search);
        var lstEmpleadosDto = _mapper.Map<List<EmpleadoDto>>(empleado.registros);
        return new Pager<EmpleadoDto>(lstEmpleadosDto,empleadoParams.Search,empleado.totalRegistros,empleadoParams.PageIndex,empleadoParams.PageSize);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EmpleadoDto>> Get(int id)
    {
        var empleado = await _unitOfWork.Empleados.GetById(id);
        if (empleado == null){
            return NotFound();
        }
        return _mapper.Map<EmpleadoDto>(empleado);
    }

    [HttpGet("EmpleadoConMayorCantidadMedicamentos")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<EmpleadoDto>> GetEmpleadoConMayorCantidadMedicamentosEn2023()
    {
        var empleado = await _unitOfWork.Empleados.GetEmpleadosConMayorCantidadMedicamentosEn2023();
        var empleadoDto = _mapper.Map<IEnumerable<EmpleadoDto>>(empleado);
        // Devuelve el empleado
        return Ok(empleadoDto);
    }

    [HttpGet("EmpleadosSinVentasAbril")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<EmpleadoDto>> EmpleadosSinVentasAbril()
    {
        var empleado = await _unitOfWork.Empleados.EmpleadosSinVentasAbril();
        var empleadoDto = _mapper.Map<IEnumerable<EmpleadoDto>>(empleado);
        // Devuelve el empleado
        return Ok(empleadoDto);
    }

    [HttpGet("GetAllEmpleadoCoonMenos5Ventas2023")]
    //[Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<EmpleadoDto>>> GetAllEmpleadoCoonMenos5Ventas2023()
    {
        var empleados = await _unitOfWork.Empleados.EmpleadoConMenosDe5Ventas();;
        return _mapper.Map<List<EmpleadoDto>>(empleados);
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
    public async Task<ActionResult<Empleado>> Post(EmpleadoDto EmpleadoDto){
        var empleado = _mapper.Map<Empleado>(EmpleadoDto);
        this._unitOfWork.Empleados.Add(empleado);
        await _unitOfWork.SaveAsync();
        if (empleado == null)
        {
            return BadRequest();
        }
        EmpleadoDto.EmpleadoId = empleado.EmpleadoId;
        return CreatedAtAction(nameof(Post),new {id= EmpleadoDto.EmpleadoId}, EmpleadoDto);
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
        public async Task<ActionResult> Update(int id , [FromBody]EmpleadoDto EmpleadoDto)
        {
            if(EmpleadoDto == null)
                return BadRequest();

            Empleado Empleado = await _unitOfWork.Empleados.GetById(id);

            _mapper.Map(EmpleadoDto, Empleado);
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