
using API.Dtos.MedicamentoCompraDtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using IncApi.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class MedicamentoCompraController : BaseApiController
{
    public MedicamentoCompraController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {

    }


    [HttpPost]
//[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(MedicamentoCompraDto MedicamentoCompraDto)
    {
            MedicamentoCompra MedicamentoCompra = _mapper.Map<MedicamentoCompra>(MedicamentoCompraDto);

            _unitOfWork.MedicamentoCompras.Add(MedicamentoCompra);

            int numeroCambios =await  _unitOfWork.SaveAsync();

            if (numeroCambios == 0) return BadRequest();

            return CreatedAtAction(nameof(Add), new {id = MedicamentoCompra.MedicamentoCompraId},MedicamentoCompra);
    }


    [HttpPost("AddRange")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<MedicamentoCompraDto> MedicamentoComprasDto)
    {
        IEnumerable<MedicamentoCompra> MedicamentoCompras = _mapper.Map<IEnumerable<MedicamentoCompra>>(MedicamentoComprasDto);
        _unitOfWork.MedicamentoCompras.AddRange(MedicamentoCompras);

        int numeroCambios = await _unitOfWork.SaveAsync();

        if(numeroCambios == 0) return BadRequest();
        foreach(MedicamentoCompra MedicamentoCompra in MedicamentoCompras)
        {
            CreatedAtAction(nameof(AddRange),new  {id= MedicamentoCompra.MedicamentoCompraId},MedicamentoCompra);
        }

        return Ok("Registros creados con exito");
    }


    [HttpGet("{id}")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<MedicamentoCompraDto>> GetByIdMedicamentoCompra(int id)
    {
        MedicamentoCompra MedicamentoCompra =await _unitOfWork.MedicamentoCompras.GetById(id);
        return _mapper.Map<MedicamentoCompraDto>(MedicamentoCompra);

    }



    [HttpGet("GetAll")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<MedicamentoCompraDto>>> GetAll()
    {
        IEnumerable<MedicamentoCompra> MedicamentoCompras = await _unitOfWork.MedicamentoCompras.GetAll();
        var MedicamentoComprasDto= _mapper.Map<IEnumerable<MedicamentoCompraDto>>(MedicamentoCompras);
        return Ok(MedicamentoComprasDto);
    }


   /*  [HttpGet("GetAllPage")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

     public async Task<ActionResult<Pager<MedicamentoCompraDepartamentoDto>>> GetChefPaginacion([FromQuery] Params MedicamentoCompraParmas)
        {
            var MedicamentoCompra = await _unitOfWork.MedicamentoCompras.GetAllAsync(MedicamentoCompraParmas.PageIndex,MedicamentoCompraParmas.PageSize,MedicamentoCompraParmas.Search);
            var listMedicamentoComprasDto =_mapper.Map<List<MedicamentoCompraDepartamentoDto>>(MedicamentoCompra.registros);

            return new Pager<MedicamentoCompraDepartamentoDto>(listMedicamentoComprasDto, MedicamentoCompraParmas.Search, MedicamentoCompra.totalRegistros, MedicamentoCompraParmas.PageIndex, MedicamentoCompraParmas.PageSize);
        } */

    [HttpDelete("{id}")]
    //[Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Delete(int id)
    {
        MedicamentoCompra MedicamentoCompra = await _unitOfWork.MedicamentoCompras.GetById(id);
        _unitOfWork.MedicamentoCompras.Remove(MedicamentoCompra);
        int numeroCambios = await  _unitOfWork.SaveAsync();
        if(numeroCambios == 0) return BadRequest();
        return Ok("Registro Borrado  con exito");
    }


    [HttpPut]
   // [Authorize(Roles="")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Update(int id, [FromBody]MedicamentoCompraDto MedicamentoCompraDto)
    {
        if(MedicamentoCompraDto == null) return BadRequest();
        MedicamentoCompra MedicamentoCompra =  await _unitOfWork.MedicamentoCompras.GetById(id);
        _mapper.Map(MedicamentoCompraDto,MedicamentoCompra);
        _unitOfWork.MedicamentoCompras.Update(MedicamentoCompra);
        int numeroCambios = await _unitOfWork.SaveAsync();
        if(numeroCambios == 0 ) return BadRequest();
        return Ok("Registro actualizado con exito");
    }
    
    




    
    
    
    
}