
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Persistence.DataSeeding;

    public class SeedingInitial
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
           /*  // Proveedores
            var ProveedorA = new Proveedor { ProveedorId =1, Nombre="ProveedorA",Telefono ="032238492",Email="ProveedorA@gmail.com",Direccion="Cra 19 # 839"};
            var ProveedorB = new Proveedor { ProveedorId = 2, Nombre = "ProveedorB", Telefono = "032238493", Email = "ProveedorB@gmail.com",Direccion="Cra 22 # 839" };
            var ProveedorC = new Proveedor { ProveedorId = 3, Nombre = "ProveedorC", Telefono = "032238494", Email = "ProveedorC@gmail.com" ,Direccion="Calle 14 # 839"};
           
            // Medicamentos
            var Paracetamol = new Medicamento {MedicamentoId =1 , Nombre = "Paracetamol", Precio=2500, Stock =150, FechaExpiracion=new DateTime(2024,06,15) , ProveedorId= ProveedorA.ProveedorId};
            var Ibuprofeno = new Medicamento { MedicamentoId = 2, Nombre = "Ibuprofeno", Precio = 3000, Stock = 100, FechaExpiracion = new DateTime( 2023,08, 15), ProveedorId = ProveedorB.ProveedorId };
            var Aspirina = new Medicamento { MedicamentoId = 3, Nombre = "Aspirina", Precio = 2000, Stock = 75, FechaExpiracion = new DateTime(2024,12, 20), ProveedorId = ProveedorC.ProveedorId };

            // Compras
            var Compra1 = new Compra {CompraId= 1, FechaCompra = new DateTime(2001,01,01),ProveedorId = ProveedorA.ProveedorId};
            var Compra2 = new Compra { CompraId = 2, FechaCompra = new DateTime( 2022,03, 15), ProveedorId = ProveedorB.ProveedorId };
            var Compra3 = new Compra { CompraId = 3, FechaCompra = new DateTime( 2023,10, 06), ProveedorId = ProveedorC.ProveedorId};

            // Pacientes
            var Paciente1 = new Paciente {PacienteId =1 , Nombre ="Sofia",Apellidos ="Alvarez",Direccion="Cra 19 #8-45 Barrio Comuneros", Telefono="3224243429"};
            var Paciente2 = new Paciente { PacienteId = 2, Nombre = "Carlos", Apellidos = "Gomez", Direccion = "Cra 25 #12-34 Barrio Los Pinos", Telefono = "3225556677" };
            var Paciente3 = new Paciente { PacienteId = 3, Nombre = "Laura", Apellidos = "Ramirez", Direccion = "Av. 4 #9-56 Barrio San Martin", Telefono = "3117778899" };

            // Cargos
            var Cargo1  = new Cargo {CargoId = 1, Nombre="Auxiliar de farmacia",Descripcion="Se encarga de atender en la farmacia"};
            var Cargo2 = new Cargo { CargoId = 2, Nombre = "Enfermera", Descripcion = "Brinda cuidados médicos a los pacientes" };
            var Cargo3 = new Cargo { CargoId = 3, Nombre = "Contador", Descripcion = "Maneja las finanzas de la empresa" };

            // Países
            var Pais1 = new Pais { PaisId =1, Nombre ="Colombia"};
            var Pais2 = new Pais { PaisId = 2, Nombre = "Perú" };
            var Pais3 = new Pais { PaisId = 3, Nombre = "Argentina" };

            // Departamentos
            var Departamento1 = new Departamento {DepartamentoId =1, Nombre="Santander",        PaisId= Pais1.PaisId};
            var Departamento2 = new Departamento {DepartamentoId =2, Nombre = "Lima",           PaisId = Pais2.PaisId };
            var Departamento3 = new Departamento {DepartamentoId =3, Nombre = "Buenos Aires",   PaisId = Pais3.PaisId };
            var Departamento4 = new Departamento {DepartamentoId =4, Nombre="Norte de Santanader", PaisId= Pais1.PaisId};
            var Departamento5 = new Departamento {DepartamentoId =5, Nombre="Cundinamarca",     PaisId= Pais1.PaisId};

            // Ciudades
            var Ciudad1 = new Ciudad {CiudadId = 1, Nombre ="Bucarmanga",DepartamentoId = Departamento1.DepartamentoId};
            var Ciudad2 = new Ciudad { CiudadId = 2, Nombre = "Lima", DepartamentoId = Departamento2.DepartamentoId };
            var Ciudad3 = new Ciudad { CiudadId = 3, Nombre = "Buenos Aires", DepartamentoId = Departamento3.DepartamentoId };
            var Ciudad4 = new Ciudad {CiudadId = 4, Nombre ="Cúcuta",DepartamentoId = Departamento4.DepartamentoId};
            var Ciudad5 = new Ciudad {CiudadId = 5, Nombre ="Bogotá",DepartamentoId = Departamento5.DepartamentoId};

            // Arls
            var Arl1 = new Arl {ArlId = 1, Nombre ="Cajasan", Telefono ="60793820", Email ="CajasanAyuda@gmail.com",Direccion ="calle 14 # 24-10"};
            var Arl2 = new Arl { ArlId = 2, Nombre = "SaludTotal", Telefono = "601234567", Email = "contacto@saludtotal.com", Direccion = "Calle 10 #30-45" };
            var Arl3 = new Arl { ArlId = 3, Nombre = "Cafesalud", Telefono = "601112233", Email = "info@cafesalud.com", Direccion = "Av. 5 #18-22" };

            // Eps
            var Eps1 = new Eps {EpsId = 1, Nombre = "Avanzar",Telefono ="60783822", Email= "AtencionAlCliente@avanzar.co", Direccion ="Calle 49 #43-2"};
            var Eps2 = new Eps { EpsId = 2, Nombre = "Coomeva", Telefono = "601987654", Email = "atencion@coomeva.com", Direccion = "Cra 15 #22-10" };
            var Eps3 = new Eps { EpsId = 3, Nombre = "Famisanar", Telefono = "601876543", Email = "info@famisanar.com", Direccion = "Av. 8 #12-30" };

            // Empleados
            var Empleado1 = new Empleado {EmpleadoId = 1, CargoId = Cargo1.CargoId, Nombres ="Jorge", Apellidos="Escalante",Direccion ="Cra 33 #48-3",Telefono ="3294902231",FechaContratacion = new DateTime(2011,02,04), CiudadId= Ciudad1.CiudadId,ArlId= Arl1.ArlId, EpsId= Eps1.EpsId};
            var Empleado2 = new Empleado { EmpleadoId = 2, CargoId = Cargo2.CargoId, Nombres = "María", Apellidos = "López", Direccion = "Cra 18 #45-6", Telefono = "3209876543", FechaContratacion = new DateTime( 2015,10, 09), CiudadId = Ciudad2.CiudadId, ArlId = Arl2.ArlId, EpsId = Eps2.EpsId };
            var Empleado3 = new Empleado { EmpleadoId = 3, CargoId = Cargo3.CargoId, Nombres = "Juan", Apellidos = "Perez", Direccion = "Av. 3 #8-15", Telefono = "3101234567", FechaContratacion = new DateTime(2019,05, 07), CiudadId = Ciudad3.CiudadId, ArlId = Arl3.ArlId, EpsId = Eps3.EpsId };

            // Ventas
            var Venta1 = new Venta {VentaId =1 , FechaVenta = new DateTime(2023,02,10),EmpleadoId = Empleado1.EmpleadoId, PacienteId = Paciente1.PacienteId};
            var Venta2 = new Venta { VentaId = 2, FechaVenta = new DateTime( 2023,04, 18), EmpleadoId = Empleado2.EmpleadoId, PacienteId = Paciente2.PacienteId };
            var Venta3 = new Venta { VentaId = 3, FechaVenta = new DateTime(2023,07, 22 ), EmpleadoId = Empleado3.EmpleadoId, PacienteId = Paciente3.PacienteId};

            //MedicamentoCompra 
           var MedicamentoCompra1 = new MedicamentoCompra {MedicamentoCompraId =1, PrecioCompra=new decimal(29383.29) ,CantidadComprada =5000, MedicamentoId =Paracetamol.MedicamentoId,CompraId= Compra1.CompraId};
            var MedicamentoCompra2 = new MedicamentoCompra {MedicamentoCompraId =2, PrecioCompra=new decimal(4583.29) ,CantidadComprada =2000, MedicamentoId = Ibuprofeno.MedicamentoId,CompraId= Compra2.CompraId};
            var MedicamentoCompra3 = new MedicamentoCompra {MedicamentoCompraId =3, PrecioCompra=new decimal(57893.29) ,CantidadComprada =100,  MedicamentoId = Aspirina.MedicamentoId,CompraId= Compra3.CompraId};

            var MedicamentoVenta1 = new MedicamentoVenta {MedicamentoVentaId =1, PrecioVenta=new decimal(29383.29),CantidadVendida =200, MedicamentoId =Paracetamol.MedicamentoId,VentaId= Venta1.VentaId};
            var MedicamentoVenta2 = new MedicamentoVenta {MedicamentoVentaId =2, PrecioVenta=new decimal(4583.29), CantidadVendida =1000, MedicamentoId = Ibuprofeno.MedicamentoId,VentaId= Venta2.VentaId};
            var MedicamentoVenta3 = new MedicamentoVenta {MedicamentoVentaId =3, PrecioVenta=new decimal(57893.29),CantidadVendida =50,  MedicamentoId = Aspirina.MedicamentoId,VentaId= Venta3.VentaId};

            //Insercion de los datos,
            modelBuilder.Entity <Pais>().HasData(Pais1, Pais2,Pais3);
            modelBuilder.Entity<Proveedor>().HasData(ProveedorA, ProveedorB, ProveedorC);
            modelBuilder.Entity<Medicamento>().HasData(Paracetamol, Aspirina, Ibuprofeno);
            modelBuilder.Entity<Compra>().HasData(Compra1,Compra2, Compra3);
            modelBuilder.Entity <Paciente>().HasData(Paciente1, Paciente2,Paciente3);
            modelBuilder.Entity<Cargo>().HasData(Cargo1,Cargo2, Cargo3);
            modelBuilder.Entity<Departamento>().HasData(Departamento1 ,Departamento2, Departamento3  ,Departamento4, Departamento5 );
            modelBuilder.Entity <Ciudad>().HasData(Ciudad1, Ciudad2,Ciudad3  ,Ciudad5,Ciudad4 );
            modelBuilder.Entity<Arl>().HasData(Arl1,Arl2, Arl3);
            modelBuilder.Entity <Eps>().HasData(Eps1, Eps2,Eps3);
            modelBuilder.Entity<Empleado>().HasData(Empleado1,Empleado2, Empleado3);
            modelBuilder.Entity <Venta>().HasData(Venta1, Venta2,Venta3);
            modelBuilder.Entity<MedicamentoVenta>().HasData(MedicamentoVenta1,MedicamentoVenta2, MedicamentoVenta3);
            modelBuilder.Entity <MedicamentoCompra>().HasData(MedicamentoCompra1, MedicamentoCompra2,MedicamentoCompra3); */
             
        }

    }
