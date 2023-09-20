
using Application.Repository;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly DotNetFarmaContext _context;
    public UnitOfWork(DotNetFarmaContext context)
    {
        _context = context;
    }

    ArlRepository _arl;
    CiudadRepository _ciudad;
    DepartamentoRepository _departamento;
    EpsRepository _eps;
    MedicamentoRepository _medicamento;
    PacienteRepository _paciente;
    PaisRepository _pais;
    ProveedorRepository _proveedor;
    RolRepository _rol;
    UsuarioRepository _usuario;
    VentaRepository _venta;

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

    public async Task<int> SaveAsyc()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}