
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Persistence.DataSeeding;

    public class SeedingInitial
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
          
              modelBuilder.Entity<Proveedor>()
                        .HasData
                        (
                            new Proveedor {ProveedorId = 1, Nombre = "ProveedorA", Telefono = "32335232", Email = "contacto@proveedora.com", Direccion = "Calle Proveedor 456"},
                            new Proveedor {ProveedorId = 2, Nombre = "ProveedorB", Telefono = "67835424", Email = "contacto@proveedorb.com", Direccion = "Calle Proveedor 789"},
                            new Proveedor {ProveedorId = 3, Nombre = "ProveedorC", Telefono = "34578724", Email = "contacto@proveedorc.com", Direccion = "Calle Proveedor 123"}
                        );

            modelBuilder.Entity<Pais>()
                        .HasData
                        (
                            new Pais {PaisId = 1, Nombre = "Colombia"},
                            new Pais {PaisId = 2, Nombre = "Argentina"},
                            new Pais {PaisId = 3, Nombre = "Mexico"}
                        );

            modelBuilder.Entity<Departamento>()
                        .HasData
                        (
                            new Departamento {DepartamentoId = 1, Nombre = "Santander", PaisId = 1},
                            new Departamento {DepartamentoId = 2, Nombre = "Buenos Aires", PaisId = 2},
                            new Departamento {DepartamentoId = 3, Nombre = "Ciudad Mexico", PaisId = 3}
                        );

            modelBuilder.Entity<Ciudad>()
                        .HasData
                        (
                            new Ciudad {CiudadId = 1, Nombre = "Bucaramanga", DepartamentoId = 1},
                            new Ciudad {CiudadId = 2, Nombre = "Piedecuesta", DepartamentoId = 1},
                            new Ciudad {CiudadId = 3, Nombre = "Giron", DepartamentoId = 1}
                        );

            modelBuilder.Entity<Cargo>()
                        .HasData
                        (
                            new Cargo {CargoId = 1, Nombre = "Gerente", Descripcion = "... Gerente"},
                            new Cargo {CargoId = 2, Nombre = "Administrador", Descripcion = "... Admin"},
                            new Cargo {CargoId = 3, Nombre = "Vendedor", Descripcion = "... Vendedor"}
                        );

            modelBuilder.Entity<Arl>()
                        .HasData
                        (
                            new Arl {ArlId = 1, Nombre = "Arl1", Telefono = "4342443324", Email = "arl1@gmail.com", Direccion = "Calle arl 456"},
                            new Arl {ArlId = 2, Nombre = "Arl2", Telefono = "2342346563", Email = "arl2@gmail.com", Direccion = "Calle arl 789"},
                            new Arl {ArlId = 3, Nombre = "Arl3", Telefono = "2457324355", Email = "arl3@gmail.com", Direccion = "Calle arl 123"}
                        );

            modelBuilder.Entity<Eps>()
                        .HasData
                        (
                            new Eps {EpsId = 1, Nombre = "Eps1", Telefono = "4342443324", Email = "eps1@gmail.com", Direccion = "Calle Eps 456"},
                            new Eps {EpsId = 2, Nombre = "Eps2", Telefono = "2342346563", Email = "eps2@gmail.com", Direccion = "Calle Eps 789"},
                            new Eps {EpsId = 3, Nombre = "Eps3", Telefono = "2457324355", Email = "eps3@gmail.com", Direccion = "Calle Eps 123"}
                        );

            modelBuilder.Entity<Paciente>()
                        .HasData
                        (
                            new Paciente {PacienteId = 1, Nombre = "Juan", Apellidos = "Perez", Direccion = "Calle 123", Telefono = "555-1234"},
                            new Paciente {PacienteId = 2, Nombre = "Maria", Apellidos = "Villamizar", Direccion = "Calle 456", Telefono = "555-5678"},
                            new Paciente {PacienteId = 3, Nombre = "Luis", Apellidos = "Garcia", Direccion = "Calle 789", Telefono = "555-9012"}
                        );

            modelBuilder.Entity<Empleado>()
                        .HasData
                        (
                            new Empleado {EmpleadoId = 1, Nombres = "Pedro", Apellidos = "Perez", Direccion = "Calle 123", Telefono = "555-1234", FechaContratacion = new DateTime(2020, 01, 01) , CargoId = 3, CiudadId = 1, ArlId = 1, EpsId = 1},
                            new Empleado {EmpleadoId = 2, Nombres = "Ana", Apellidos = "Villamizar", Direccion = "Calle 123", Telefono = "555-1234", FechaContratacion = new DateTime(2019, 05, 15) , CargoId = 3, CiudadId = 1, ArlId = 2, EpsId = 2},
                            new Empleado {EmpleadoId = 3, Nombres = "Luis", Apellidos = "Garcia", Direccion = "Calle 123", Telefono = "555-1234", FechaContratacion = new DateTime(2018, 02, 10) , CargoId = 1, CiudadId = 1, ArlId = 3, EpsId = 3},
                            new Empleado {EmpleadoId = 4, Nombres = "Sofia", Apellidos = "Garcia", Direccion = "Calle 123", Telefono = "555-1234", FechaContratacion = new DateTime(2021, 03, 01) , CargoId = 2, CiudadId = 1, ArlId = 1, EpsId = 3}
                            
                        );

            modelBuilder.Entity<Compra>()
                        .HasData
                        (
                            new Compra {CompraId = 1, FechaCompra = new DateTime(2023, 01, 01), ProveedorId = 1},
                            new Compra {CompraId = 2, FechaCompra = new DateTime(2023, 01, 10), ProveedorId = 2},
                            new Compra {CompraId = 3, FechaCompra = new DateTime(2023, 02, 01), ProveedorId = 3},
                            new Compra {CompraId = 4, FechaCompra = new DateTime(2023, 02, 15), ProveedorId = 1},
                            new Compra {CompraId = 5, FechaCompra = new DateTime(2023, 03, 05), ProveedorId = 2},
                            new Compra {CompraId = 6, FechaCompra = new DateTime(2023, 04, 01), ProveedorId = 3},
                            new Compra {CompraId = 7, FechaCompra = new DateTime(2023, 04, 20), ProveedorId = 1},
                            new Compra {CompraId = 8, FechaCompra = new DateTime(2023, 05, 05), ProveedorId = 2},
                            new Compra {CompraId = 9, FechaCompra = new DateTime(2023, 06, 10), ProveedorId = 3},
                            new Compra {CompraId = 10, FechaCompra = new DateTime(2023, 06, 30), ProveedorId = 1}
                        );

            modelBuilder.Entity<Medicamento>()
                        .HasData
                        (
                            new Medicamento {MedicamentoId = 1, Nombre = "Paracetamol", Precio = 20, Stock = 150, FechaExpiracion = new DateTime(2024, 06, 15), ProveedorId = 1},
                            new Medicamento {MedicamentoId = 2, Nombre = "Ibuprofeno", Precio = 25, Stock = 50, FechaExpiracion = new DateTime(2024, 12, 01), ProveedorId = 2},
                            new Medicamento {MedicamentoId = 3, Nombre = "Aspirina", Precio = 15, Stock = 30, FechaExpiracion = new DateTime(2024, 05, 20), ProveedorId = 3},
                            new Medicamento {MedicamentoId = 4, Nombre = "Amoxicilina", Precio = 40, Stock = 75, FechaExpiracion = new DateTime(2025, 08, 11), ProveedorId = 1},
                            new Medicamento {MedicamentoId = 5, Nombre = "Cetirizina", Precio = 10, Stock = 110, FechaExpiracion = new DateTime(2024, 01, 23), ProveedorId = 2},
                            new Medicamento {MedicamentoId = 6, Nombre = "Losartan", Precio = 55, Stock = 95, FechaExpiracion = new DateTime(2024, 07, 30), ProveedorId = 3},
                            new Medicamento {MedicamentoId = 7, Nombre = "Metformina", Precio = 60, Stock = 180, FechaExpiracion = new DateTime(2024, 09, 29), ProveedorId = 1},
                            new Medicamento {MedicamentoId = 8, Nombre = "Atorvastatina", Precio = 45, Stock = 200, FechaExpiracion = new DateTime(2024, 10, 05), ProveedorId = 2},
                            new Medicamento {MedicamentoId = 9, Nombre = "Clonazepam", Precio = 35, Stock = 25, FechaExpiracion = new DateTime(2024, 04, 21), ProveedorId = 3},
                            new Medicamento {MedicamentoId = 10, Nombre = "Loratadina", Precio = 22, Stock = 120, FechaExpiracion = new DateTime(2025, 02, 19), ProveedorId = 1}
                        );

            modelBuilder.Entity<Venta>()
                        .HasData
                        (
                            new Venta {VentaId = 1, FechaVenta= new DateTime(2023, 01, 10), EmpleadoId = 1, PacienteId = 1},
                            new Venta {VentaId = 2, FechaVenta= new DateTime(2023, 01, 15), EmpleadoId = 2, PacienteId = 2},
                            new Venta {VentaId = 3, FechaVenta= new DateTime(2023, 02, 05), EmpleadoId = 1, PacienteId = 3},
                            new Venta {VentaId = 4, FechaVenta= new DateTime(2023, 02, 12), EmpleadoId = 1, PacienteId = 2},
                            new Venta {VentaId = 5, FechaVenta= new DateTime(2023, 03, 10), EmpleadoId = 2, PacienteId = 1},
                            new Venta {VentaId = 6, FechaVenta= new DateTime(2023, 04, 15), EmpleadoId = 2, PacienteId = 2},
                            new Venta {VentaId = 7, FechaVenta= new DateTime(2023, 05, 05), EmpleadoId = 1, PacienteId = 2},
                            new Venta {VentaId = 8, FechaVenta= new DateTime(2023, 05, 25), EmpleadoId = 1, PacienteId = 2},
                            new Venta {VentaId = 9, FechaVenta= new DateTime(2023, 06, 10), EmpleadoId = 2, PacienteId = 1},
                            new Venta {VentaId = 10, FechaVenta = new DateTime(2023, 06, 30), EmpleadoId = 2, PacienteId = 2}
                        );

            modelBuilder.Entity<MedicamentoCompra>()
                        .HasData
                        (
                            new MedicamentoCompra {MedicamentoCompraId = 1, CompraId = 1, MedicamentoId = 1, CantidadComprada = 50, PrecioCompra = 15},
                            new MedicamentoCompra {MedicamentoCompraId = 2, CompraId = 2, MedicamentoId = 2, CantidadComprada = 25, PrecioCompra = 20},
                            new MedicamentoCompra {MedicamentoCompraId = 3, CompraId = 3, MedicamentoId = 3, CantidadComprada = 10, PrecioCompra = 12},
                            new MedicamentoCompra {MedicamentoCompraId = 4, CompraId = 4, MedicamentoId = 4, CantidadComprada = 30, PrecioCompra = 35},
                            new MedicamentoCompra {MedicamentoCompraId = 5, CompraId = 5, MedicamentoId = 5, CantidadComprada = 50, PrecioCompra = 8},
                            new MedicamentoCompra {MedicamentoCompraId = 6, CompraId = 6, MedicamentoId = 6, CantidadComprada = 40, PrecioCompra = 50},
                            new MedicamentoCompra {MedicamentoCompraId = 7, CompraId = 7, MedicamentoId = 7, CantidadComprada = 60, PrecioCompra = 55},
                            new MedicamentoCompra {MedicamentoCompraId = 8, CompraId = 8, MedicamentoId = 8, CantidadComprada = 70, PrecioCompra = 40},
                            new MedicamentoCompra {MedicamentoCompraId = 9, CompraId = 9, MedicamentoId = 9, CantidadComprada = 15, PrecioCompra = 32},
                            new MedicamentoCompra {MedicamentoCompraId = 10,CompraId =10 ,MedicamentoId = 10,CantidadComprada = 50, PrecioCompra = 20}
                        );

            modelBuilder.Entity<MedicamentoVenta>()
                        .HasData
                        (
                            new MedicamentoVenta {MedicamentoVentaId = 1, VentaId = 1, MedicamentoId = 1,CantidadVendida = 2, PrecioVenta = 20},
                            new MedicamentoVenta {MedicamentoVentaId = 2, VentaId = 2, MedicamentoId = 2,CantidadVendida = 1, PrecioVenta = 25},
                            new MedicamentoVenta {MedicamentoVentaId = 3, VentaId = 2, MedicamentoId = 3,CantidadVendida = 2, PrecioVenta = 15},
                            new MedicamentoVenta {MedicamentoVentaId = 4, VentaId = 3, MedicamentoId = 4,CantidadVendida = 1, PrecioVenta = 40},
                            new MedicamentoVenta {MedicamentoVentaId = 5, VentaId = 4, MedicamentoId = 5,CantidadVendida = 1, PrecioVenta = 10},
                            new MedicamentoVenta {MedicamentoVentaId = 6, VentaId = 5, MedicamentoId = 6,CantidadVendida = 1, PrecioVenta = 55},
                            new MedicamentoVenta {MedicamentoVentaId = 7, VentaId = 6, MedicamentoId = 7,CantidadVendida = 1, PrecioVenta = 60},
                            new MedicamentoVenta {MedicamentoVentaId = 8, VentaId = 7, MedicamentoId = 8,CantidadVendida = 1, PrecioVenta = 45},
                            new MedicamentoVenta {MedicamentoVentaId = 9, VentaId = 8, MedicamentoId = 9,CantidadVendida = 1, PrecioVenta = 35},
                            new MedicamentoVenta {MedicamentoVentaId = 10, VentaId = 9, MedicamentoId = 10,CantidadVendida = 1, PrecioVenta = 22},
                            new MedicamentoVenta {MedicamentoVentaId = 11, VentaId = 10,MedicamentoId = 1,CantidadVendida = 2, PrecioVenta = 20}
                        );
        }

    }
