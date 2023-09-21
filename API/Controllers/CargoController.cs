using API.Dtos.CargoDto;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using IncApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
// Cargo, cargo, Cargos, cargos
public class CargoController : BaseApiController
{
    public CargoController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    
    }
   /* [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<Cargo>>> Get()
    {
        var regiones = await _unitOfWork.Cargos.GetAllAsync();
        return Ok(regiones);
    }*/
    [HttpGet]
    /* [Authorize(Roles = "Administrador")] */
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<CargoDto>>> Get()
    {
        var cargos = await _unitOfWork.Cargos.GetAll();
        return _mapper.Map<List<CargoDto>>(cargos);
    }
    [HttpGet("Pager")]
    /* [Authorize] */
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<CargoDto>>> Get11([FromQuery] Params cargoParams)
    {
        var cargo = await _unitOfWork.Cargos.GetAllAsync(cargoParams.PageIndex,cargoParams.PageSize,cargoParams.Search);
        var lstCargosDto = _mapper.Map<List<CargoDto>>(cargo.registros);
        return new Pager<CargoDto>(lstCargosDto,cargoParams.Search,cargo.totalRegistros,cargoParams.PageIndex,cargoParams.PageSize);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CargoDto>> Get(int id)
    {
        var cargo = await _unitOfWork.Cargos.GetById(id);
        if (cargo == null){
            return NotFound();
        }
        return _mapper.Map<CargoDto>(cargo);
    }
    /*[HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Cargo>> Post(Cargo cargo){
        this._unitOfWork.Cargos.Add(cargo);
        await _unitOfWork.SaveAsync();
        if (cargo == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= cargo.Id}, cargo);
    }*/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Cargo>> Post(CargoDto cargoDto){
        var cargo = _mapper.Map<Cargo>(cargoDto);
        this._unitOfWork.Cargos.Add(cargo);
        await _unitOfWork.SaveAsync();
        if (cargo == null)
        {
            return BadRequest();
        }
        cargoDto.CargoId = cargo.CargoId;
        return CreatedAtAction(nameof(Post),new {id= cargoDto.CargoId}, cargoDto);
    }
    /*[HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Put(int id, [FromBody]Area cargo){
        if(cargo == null)
            return NotFound();
        _unitOfWork.Cargos.Update(cargo);
        await _unitOfWork.SaveAsync();
        return cargo;
        
    }*/
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update(int id , [FromBody]CargoDto CargoDto)
        {
            if(CargoDto == null)
                return BadRequest();

            Cargo Cargo = await _unitOfWork.Cargos.GetById(id);

            _mapper.Map(CargoDto, Cargo);
            _unitOfWork.Cargos.Update(Cargo);

            int num = await _unitOfWork.SaveAsync();

            if(num == 0)
                return BadRequest();

            return Ok("REGISTRO ACTUALIZADO CON EXITO");
        }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var cargo = await _unitOfWork.Cargos.GetById(id);
        if(cargo == null){
            return NotFound();
        }
        _unitOfWork.Cargos.Remove(cargo);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}