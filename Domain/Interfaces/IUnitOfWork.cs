namespace Domain.Interfaces;


public interface IUnitOfWork
{

    public IUsuario Usuarios {get;}
    public IProveedor Proveedores {get;}
    public IPaciente Pacientes { get; }
    public IPais Paises { get;}
 
    
}