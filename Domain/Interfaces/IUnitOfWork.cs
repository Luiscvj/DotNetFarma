namespace Domain.Interfaces;


public interface IUnitOfWork
{
    public IArl Arls { get; }
    public ICargo Cargos {get;}
    public ICiudad Ciudades { get; }
    public ICompra Compras { get;}
    public IDepartamento Departamentos { get; }
    public IEmpleado Empleados {get; }
    public IEps Eps { get; }
    public IMedicamento Medicamentos { get; }
    public IMedicamentoCompra MedicamentoCompras { get; }
    public IMedicamentoVenta MedicamentoIMedicamentoVentas { get; }
    public IPaciente Pacientes { get; }
    public IPais Paises { get;}
    public IProveedor Proveedores {get;}
    public IRefreshToken RefreshIRefreshTokens { get; }
    public IRol Roles { get; }
    public IUsuario Usuarios {get;}
    public IVenta Ventas { get; }
    Task<int> SaveAsync();
}