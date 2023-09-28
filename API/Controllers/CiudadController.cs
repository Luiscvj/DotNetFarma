

using API.Dtos.CiudadDtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

using IncApi.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CiudadController : BaseApiController
    {
        public CiudadController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet("all")]
        // [Authorize(Roles = "Administrador, Gerente")]
        // [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<CiudadDto>>> Get()
        {
            var registros = await _unitOfWork.Ciudades.GetAll();
            if(registros == null) return NotFound();
            return _mapper.Map<List<CiudadDto>>(registros);   
        }

        [HttpGet("{id}")]
        // [Authorize(Roles = "Administrador, Gerente")]
        // [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CiudadDto>> GetById(int id)
        {
            var registro = await _unitOfWork.Ciudades.GetById(id);
            if(registro == null) return NotFound(); 
            return _mapper.Map<CiudadDto>(registro);
        }

        [HttpPost]
        // [Authorize(Roles = "Administrador, Gerente")]
        // [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CiudadDto>> Post(CiudadDto data)
        {
            var registro = _mapper.Map<Ciudad>(data);
            if(registro == null) return BadRequest();
            _unitOfWork.Ciudades.Add(registro);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Post), new { id = registro.CiudadId }, registro);
        }

        [HttpPut("{id}")]
        // [Authorize(Roles = "Administrador, Gerente")]
        // [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CiudadDto>> Put(int id, [FromBody] CiudadDto dataUpdate)
        {
            if(dataUpdate == null) return NotFound();
            var registro = _mapper.Map<Ciudad>(dataUpdate);
            registro.CiudadId = id;
            _unitOfWork.Ciudades.Update(registro);
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
            var registro = await _unitOfWork.Ciudades.GetById(id);
            if(registro == null) return NotFound();
            _unitOfWork.Ciudades.Remove(registro);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

       /* [HttpGet("pager")]
        // [Authorize]
        // [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
         public async Task<ActionResult<Pager<CiudadDto>>> GetAreaWhithPage([FromQuery] Params parameters)
        {
            var registros = await _unitOfWork.Ciudades.GetAllAsync
            (
                parameters.PageIndex,
                parameters.PageSize,
                parameters.Search
            );
            var lstAreas = _mapper.Map<List<CiudadDto>>(registros.registros);
            return new Pager<CiudadDto>
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