

using API.Dtos.EpsDtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EpsController : BaseApiController
    {
        public EpsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet("all")]
        // [Authorize(Roles = "Administrador, Gerente")]
        // [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<EpsDto>>> Get()
        {
            var registros = await _unitOfWork.Eps.GetAll();
            if(registros == null) return NotFound();
            return _mapper.Map<List<EpsDto>>(registros);   
        }

        [HttpGet("{id}")]
        // [Authorize(Roles = "Administrador, Gerente")]
        // [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EpsDto>> GetById(int id)
        {
            var registro = await _unitOfWork.Eps.GetById(id);
            if(registro == null) return NotFound(); 
            return _mapper.Map<EpsDto>(registro);
        }

        [HttpPost]
        // [Authorize(Roles = "Administrador, Gerente")]
        // [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EpsDto>> Post(EpsDto data)
        {
            var registro = _mapper.Map<Eps>(data);
            if(registro == null) return BadRequest();
            _unitOfWork.Eps.Add(registro);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Post), new { id = registro.EpsId }, registro);
        }

        [HttpPut("{id}")]
        // [Authorize(Roles = "Administrador, Gerente")]
        // [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EpsDto>> Put(int id, [FromBody] EpsDto dataUpdate)
        {
            if(dataUpdate == null) return NotFound();
            var registro = _mapper.Map<Eps>(dataUpdate);
            registro.EpsId = id;
            _unitOfWork.Eps.Update(registro);
            await _unitOfWork.SaveAsync();
            return dataUpdate;
        }

        [HttpDelete("{id}")]
        // [Authorize(Roles = "Administrador, Gerente")]
        // [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var registro = await _unitOfWork.Eps.GetById(id);
            if(registro == null) return NotFound();
            _unitOfWork.Eps.Remove(registro);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
/* 
        [HttpGet("pager")]
        // [Authorize]
        // [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<EpsDto>>> GetAreaWhithPage([FromQuery] Params parameters)
        {
            var registros = await _unitOfWork.Eps.GetAllAsync
            (
                parameters.PageIndex,
                parameters.PageSize,
                parameters.Search
            );
            var lstAreas = _mapper.Map<List<EpsDto>>(registros.registros);
            return new Pager<EpsDto>
            (
                lstAreas,
                registros.totalRegistros,
                parameters.PageIndex,
                parameters.PageSize,
                parameters.Search
            );
        } */
    }
}