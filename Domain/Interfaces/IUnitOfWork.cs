namespace Domain.Interfaces;


public interface IUnitOfWork
{
    public IArl Arls { get; }
    public ICiudad Ciudades { get; }
    public IDepartamento Departamentos { get; }
    public IEps Eps { get; }
    public IMedicamento Medicamentos { get; }
    public IRol Roles { get; }
    public IVenta Ventas { get; }
    public IUsuario Usuarios {get;}
    public IProveedor Proveedores {get;}
    public IPaciente Pacientes { get; }
    public IPais Paises { get;}
    Task<int> SaveAsyc();
}