using API.Dtos.CompraDto;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using IncApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
// Compra, compra, Compras, compras
public class CompraController : BaseApiController
{
    public CompraController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    
    }
   /* [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<Compra>>> Get()
    {
        var regiones = await _unitOfWork.Compras.GetAllAsync();
        return Ok(regiones);
    }*/
    [HttpGet]
    [Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async  Task<ActionResult<IEnumerable<CompraDto>>> Get()
    {
        var compras = await _unitOfWork.Compras.GetAll();
        return _mapper.Map<List<CompraDto>>(compras);
    }
    [HttpGet("Pager")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<CompraDto>>> Get11([FromQuery] Params compraParams)
    {
        var compra = await _unitOfWork.Compras.GetAllAsync(compraParams.PageIndex,compraParams.PageSize,compraParams.Search);
        var lstComprasDto = _mapper.Map<List<CompraDto>>(compra.registros);
        return new Pager<CompraDto>(lstComprasDto,compraParams.Search,compra.totalRegistros,compraParams.PageIndex,compraParams.PageSize);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CompraDto>> Get(int id)
    {
        var compra = await _unitOfWork.Compras.GetById(id);
        if (compra == null){
            return NotFound();
        }
        return _mapper.Map<CompraDto>(compra);
    }
    /*[HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Compra>> Post(Compra compra){
        this._unitOfWork.Compras.Add(compra);
        await _unitOfWork.SaveAsync();
        if (compra == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id= compra.Id}, compra);
    }*/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Compra>> Post(CompraDto compraDto){
        var compra = _mapper.Map<Compra>(compraDto);
        this._unitOfWork.Compras.Add(compra);
        await _unitOfWork.SaveAsync();
        if (compra == null)
        {
            return BadRequest();
        }
        compraDto.CompraId = compra.CompraId;
        return CreatedAtAction(nameof(Post),new {id= compraDto.CompraId}, compraDto);
    }
    /*[HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Put(int id, [FromBody]Area compra){
        if(compra == null)
            return NotFound();
        _unitOfWork.Compras.Update(compra);
        await _unitOfWork.SaveAsync();
        return compra;
        
    }*/
    [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update(int id , [FromBody]CompraDto CompraDto)
        {
            if(CompraDto == null)
                return BadRequest();

            Compra Compra = await _unitOfWork.Compras.GetById(id);

            _mapper.Map(CompraDto, Compra);
            _unitOfWork.Compras.Update(Compra);

            int num = await _unitOfWork.SaveAsync();

            if(num == 0)
                return BadRequest();

            return Ok("REGISTRO ACTUALIZADO CON EXITO");
        }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var compra = await _unitOfWork.Compras.GetById(id);
        if(compra == null){
            return NotFound();
        }
        _unitOfWork.Compras.Remove(compra);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}