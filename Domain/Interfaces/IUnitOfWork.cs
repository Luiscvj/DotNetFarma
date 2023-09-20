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
    public ICargo Cargos {get;}
    public ICompra Compras { get;}
    IEmpleado Empleados {get; }
    Task<int> SaveAsync();
}