using Domain.Entities;

namespace Domain.Interfaces;

public interface IPaciente : IGenericRepository<Paciente>
{
   public  Task<List<MedicamentoPorPacienteH>> MedicamentoPacientePorNombreMedicamento(string NombreMedicamento);
   Task<dynamic> GetPacienteMasDineroGastado();

}