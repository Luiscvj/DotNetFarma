using Domain.Entities;

namespace Domain.Interfaces;

public interface IPaciente : IGenericRepository<Paciente>
{
    Task<List<Paciente>> PacientesParacetamol();
    Task<List<Paciente>> PacientesSinComprasEn2023();
    Task<Dictionary<string, decimal>> TotalGastadoPorPacienteEn2023();
}