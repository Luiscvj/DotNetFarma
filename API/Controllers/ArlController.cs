
using API.Dtos.ArlDto;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using IncApi.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ArlController : BaseApiController
{
    public ArlController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<ArlDto>> Get()
    {
        var registros = await _unitOfWork.Arls.GetAll();
        return _mapper.Map<List<ArlDto>>(registros);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ArlDto> GetById(int id)
    {
        var registro = await _unitOfWork.Arls.GetById(id);
        return _mapper.Map<ArlDto>(registro);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ArlDto>> Post(ArlDto data)
    {
        if(data == null) return BadRequest();
        var registro = _mapper.Map<Arl>(data);
        _unitOfWork.Arls.Add(registro);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(Post), new {id = registro.ArlId}, registro);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ArlDto>> Put(int id, [FromBody] ArlDto updateData)
    {
        if(updateData == null) return NotFound();
        var registro = _mapper.Map<Arl>(updateData);
        registro.ArlId = id;
        _unitOfWork.Arls.Update(registro);
        await _unitOfWork.SaveAsync();
        return updateData;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var registro = await _unitOfWork.Arls.GetById(id);
        if(registro == null) return NotFound();
        _unitOfWork.Arls.Remove(registro);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    // [HttpGet("pager")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // public async Task<ActionResult<Pager<ArlxDtosDto>>> GetWhithPage([FromQuery] Params arlParams)
    // {
    //     var (totalRegistros, registros) = await _unitOfWork.Arls.GetAllAsync
    //     (
    //         arlParams.PageIndex,
    //         arlParams.PageSize,
    //         arlParams.Search
    //     );
    //     var lstarl = _mapper.Map<List<ArlxDtosDto>>(registros);
    //     return new Pager<ArlxDtosDto>
    //     (
    //         lstarl,
    //         arlParams.Search,
    //         totalRegistros,
    //         arlParams.PageIndex,
    //         arlParams.PageSize
    //     );
    // }
}   
