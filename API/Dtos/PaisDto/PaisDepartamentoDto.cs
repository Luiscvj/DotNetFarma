using API.Dtos.DepartamentoDtos;

namespace API.Dtos.PaisDto;



public class PaisDepartamentoDto
{
    public int PaisId { get; set; }
    public string Nombre { get; set; }
    public List<DepartamentoDto> Departamentos { get; set; }   
}
