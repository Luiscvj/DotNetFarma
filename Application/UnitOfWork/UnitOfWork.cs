
using Application.Repository;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{

    ArlRepository _arl;
    CargoRepository _cargo;
    CiudadRepository _ciudad;
    CompraRepository _compra;
    DepartamentoRepository _departamento;
    EmpleadoRepository _empleado;
    EpsRepository _eps;
    MedicamentoRepository _medicamento;
    MedicamentoCompraRepository _medicamentoCompra;
    MedicamentoVentaRepository _medicamentoVenta;
    PacienteRepository _paciente;
    PaisRepository _pais;
    ProveedorRepository _proveedor;
    RefreshTokenRepository _refreshToken;
    RolRepository _rol;
    UsuarioRepository _usuario;
    VentaRepository _venta;
   

    private readonly DotNetFarmaContext _context;
    public UnitOfWork(DotNetFarmaContext context)
    {
        _context = context;
    }
    public IArl Arls
    {
        get
        {
            _arl ??= new ArlRepository(_context);
            return _arl;
        }
    }

    public ICiudad Ciudades
    {
        get
        {
            _ciudad ??= new CiudadRepository(_context);
            return _ciudad;
        }
    }

    public IDepartamento Departamentos
    {
        get
        {
            _departamento ??= new DepartamentoRepository(_context);
            return _departamento;
        }
    }

    public IEps Eps
    {
        get
        {
            _eps ??= new EpsRepository(_context);
            return _eps;
        }
    }

    public IMedicamento Medicamentos
    {
        get
        {
            _medicamento ??= new MedicamentoRepository(_context);
            return _medicamento;
        }
    }

    public IRol Roles
    {
        get
        {
            _rol ??= new RolRepository(_context);
            return _rol;
        }
    }

    public IVenta Ventas
    {
        get
        {
            _venta ??= new VentaRepository(_context);
            return _venta;
        }
    }

    public IUsuario Usuarios
    {
        get
        {
            _usuario ??= new UsuarioRepository(_context);
            return _usuario;
        }
    }

    public IProveedor Proveedores
    {
        get
        {
            _proveedor ??= new ProveedorRepository(_context);
            return _proveedor;
        }
    }

    public IPaciente Pacientes
    {
        get
        {
            _paciente ??= new PacienteRepository(_context);
            return _paciente;
        }
    }

    public IPais Paises
    {
        get
        {
            _pais ??= new PaisRepository(_context);
            return _pais;
        }
    }

    public ICargo Cargos
    {
        get
        {
            _cargo ??= new CargoRepository(_context);
            return _cargo;
        }
    }

    public IEmpleado Empleados
    {
        get
        {
            _empleado ??= new EmpleadoRepository(_context);
            return _empleado;
        }
    }

    public ICompra Compras
    {
        get
        {
            _compra ??= new CompraRepository(_context);
            return _compra;
        }
    }

    public IMedicamentoCompra MedicamentoCompras
    {
        get
        {
            _medicamentoCompra ??= new MedicamentoCompraRepository(_context);
            return _medicamentoCompra;
        }
    }

    public IMedicamentoVenta MedicamentoIMedicamentoVentas
    {
        get
        {
            _medicamentoVenta ??= new MedicamentoVentaRepository(_context);
            return _medicamentoVenta;
        }
    }

    public IRefreshToken RefreshIRefreshTokens
    {
        get
        {
            _refreshToken ??= new RefreshTokenRepository(_context);
            return _refreshToken;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
