using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "arl",
                columns: table => new
                {
                    ArlId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_arl", x => x.ArlId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    CargoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.CargoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "eps",
                columns: table => new
                {
                    EpsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eps", x => x.EpsId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "paciente",
                columns: table => new
                {
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellidos = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paciente", x => x.PacienteId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pais",
                columns: table => new
                {
                    PaisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pais", x => x.PaisId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "proveedor",
                columns: table => new
                {
                    ProveedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedor", x => x.ProveedorId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.RolId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    DepartamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamento", x => x.DepartamentoId);
                    table.ForeignKey(
                        name: "FK_departamento_pais_PaisId",
                        column: x => x.PaisId,
                        principalTable: "pais",
                        principalColumn: "PaisId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medicamento",
                columns: table => new
                {
                    MedicamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Precio = table.Column<double>(type: "double", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    FechaExpiracion = table.Column<DateTime>(type: "date", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicamento", x => x.MedicamentoId);
                    table.ForeignKey(
                        name: "FK_medicamento_proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "proveedor",
                        principalColumn: "ProveedorId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_usuario_rol_RolId",
                        column: x => x.RolId,
                        principalTable: "rol",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ciudad",
                columns: table => new
                {
                    CiudadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ciudad", x => x.CiudadId);
                    table.ForeignKey(
                        name: "FK_ciudad_departamento_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "departamento",
                        principalColumn: "DepartamentoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    CompraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaCompra = table.Column<DateTime>(type: "date", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    MedicamentoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.CompraId);
                    table.ForeignKey(
                        name: "FK_Compra_medicamento_MedicamentoId",
                        column: x => x.MedicamentoId,
                        principalTable: "medicamento",
                        principalColumn: "MedicamentoId");
                    table.ForeignKey(
                        name: "FK_Compra_proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "proveedor",
                        principalColumn: "ProveedorId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "refresh_token",
                columns: table => new
                {
                    RefreshTokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Token = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    IsExpired = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "date", nullable: false),
                    FechaExpiracion = table.Column<DateTime>(type: "date", nullable: false),
                    Revocado = table.Column<DateTime>(type: "date", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refresh_token", x => x.RefreshTokenId);
                    table.ForeignKey(
                        name: "FK_refresh_token_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CargoId = table.Column<int>(type: "int", nullable: false),
                    Nombres = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellidos = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaContratacion = table.Column<DateTime>(type: "date", nullable: false),
                    CiudadId = table.Column<int>(type: "int", nullable: false),
                    ArlId = table.Column<int>(type: "int", nullable: false),
                    EpsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.EmpleadoId);
                    table.ForeignKey(
                        name: "FK_Empleado_Cargo_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargo",
                        principalColumn: "CargoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empleado_arl_ArlId",
                        column: x => x.ArlId,
                        principalTable: "arl",
                        principalColumn: "ArlId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empleado_ciudad_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "ciudad",
                        principalColumn: "CiudadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empleado_eps_EpsId",
                        column: x => x.EpsId,
                        principalTable: "eps",
                        principalColumn: "EpsId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "table_name",
                columns: table => new
                {
                    MedicamentoCompraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CantidadComprada = table.Column<int>(type: "int", nullable: false),
                    PrecioCompra = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: false),
                    CompraId = table.Column<int>(type: "int", nullable: false),
                    MedicamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table_name", x => x.MedicamentoCompraId);
                    table.ForeignKey(
                        name: "FK_table_name_Compra_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compra",
                        principalColumn: "CompraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_table_name_medicamento_MedicamentoId",
                        column: x => x.MedicamentoId,
                        principalTable: "medicamento",
                        principalColumn: "MedicamentoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "venta",
                columns: table => new
                {
                    VentaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaVenta = table.Column<DateTime>(type: "datetime", nullable: false),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    MedicamentoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_venta", x => x.VentaId);
                    table.ForeignKey(
                        name: "FK_venta_Empleado_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_venta_medicamento_MedicamentoId",
                        column: x => x.MedicamentoId,
                        principalTable: "medicamento",
                        principalColumn: "MedicamentoId");
                    table.ForeignKey(
                        name: "FK_venta_paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "paciente",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medicamento_venta",
                columns: table => new
                {
                    MedicamentoVentaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CantidadVendida = table.Column<int>(type: "int", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: false),
                    VentaId = table.Column<int>(type: "int", nullable: false),
                    MedicamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicamento_venta", x => x.MedicamentoVentaId);
                    table.ForeignKey(
                        name: "FK_medicamento_venta_medicamento_MedicamentoId",
                        column: x => x.MedicamentoId,
                        principalTable: "medicamento",
                        principalColumn: "MedicamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medicamento_venta_venta_VentaId",
                        column: x => x.VentaId,
                        principalTable: "venta",
                        principalColumn: "VentaId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Cargo",
                columns: new[] { "CargoId", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, "Se encarga de atender en la farmacia", "Auxiliar de farmacia" },
                    { 2, "Brinda cuidados médicos a los pacientes", "Enfermera" },
                    { 3, "Maneja las finanzas de la empresa", "Contador" }
                });

            migrationBuilder.InsertData(
                table: "arl",
                columns: new[] { "ArlId", "Direccion", "Email", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "calle 14 # 24-10", "CajasanAyuda@gmail.com", "Cajasan", "60793820" },
                    { 2, "Calle 10 #30-45", "contacto@saludtotal.com", "SaludTotal", "601234567" },
                    { 3, "Av. 5 #18-22", "info@cafesalud.com", "Cafesalud", "601112233" }
                });

            migrationBuilder.InsertData(
                table: "eps",
                columns: new[] { "EpsId", "Direccion", "Email", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Calle 49 #43-2", "AtencionAlCliente@avanzar.co", "Avanzar", "60783822" },
                    { 2, "Cra 15 #22-10", "atencion@coomeva.com", "Coomeva", "601987654" },
                    { 3, "Av. 8 #12-30", "info@famisanar.com", "Famisanar", "601876543" }
                });

            migrationBuilder.InsertData(
                table: "paciente",
                columns: new[] { "PacienteId", "Apellidos", "Direccion", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Alvarez", "Cra 19 #8-45 Barrio Comuneros", "Sofia", "3224243429" },
                    { 2, "Gomez", "Cra 25 #12-34 Barrio Los Pinos", "Carlos", "3225556677" },
                    { 3, "Ramirez", "Av. 4 #9-56 Barrio San Martin", "Laura", "3117778899" }
                });

            migrationBuilder.InsertData(
                table: "pais",
                columns: new[] { "PaisId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Colombia" },
                    { 2, "Perú" },
                    { 3, "Argentina" }
                });

            migrationBuilder.InsertData(
                table: "proveedor",
                columns: new[] { "ProveedorId", "Direccion", "Email", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Cra 19 # 839", "ProveedorA@gmail.com", "ProveedorA", "032238492" },
                    { 2, "Cra 22 # 839", "ProveedorB@gmail.com", "ProveedorB", "032238493" },
                    { 3, "Calle 14 # 839", "ProveedorC@gmail.com", "ProveedorC", "032238494" }
                });

            migrationBuilder.InsertData(
                table: "Compra",
                columns: new[] { "CompraId", "Cantidad", "FechaCompra", "MedicamentoId", "Precio", "ProveedorId" },
                values: new object[,]
                {
                    { 1, 200, new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 200000, 1 },
                    { 2, 150, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 180000, 2 },
                    { 3, 100, new DateTime(2023, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 150000, 3 }
                });

            migrationBuilder.InsertData(
                table: "departamento",
                columns: new[] { "DepartamentoId", "Nombre", "PaisId" },
                values: new object[,]
                {
                    { 1, "Santander", 1 },
                    { 2, "Lima", 2 },
                    { 3, "Buenos Aires", 3 },
                    { 4, "Norte de Santanader", 1 },
                    { 5, "Cundinamarca", 1 }
                });

            migrationBuilder.InsertData(
                table: "medicamento",
                columns: new[] { "MedicamentoId", "FechaExpiracion", "Nombre", "Precio", "ProveedorId", "Stock" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paracetamol", 2500.0, 1, 150 },
                    { 2, new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ibuprofeno", 3000.0, 2, 100 },
                    { 3, new DateTime(2024, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aspirina", 2000.0, 3, 75 }
                });

            migrationBuilder.InsertData(
                table: "ciudad",
                columns: new[] { "CiudadId", "DepartamentoId", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Bucarmanga" },
                    { 2, 2, "Lima" },
                    { 3, 3, "Buenos Aires" },
                    { 4, 4, "Cúcuta" },
                    { 5, 5, "Bogotá" }
                });

            migrationBuilder.InsertData(
                table: "table_name",
                columns: new[] { "MedicamentoCompraId", "CantidadComprada", "CompraId", "MedicamentoId", "PrecioCompra" },
                values: new object[,]
                {
                    { 1, 5000, 1, 1, 29383.29m },
                    { 2, 2000, 2, 2, 4583.29m },
                    { 3, 100, 3, 3, 57893.29m }
                });

            migrationBuilder.InsertData(
                table: "Empleado",
                columns: new[] { "EmpleadoId", "Apellidos", "ArlId", "CargoId", "CiudadId", "Direccion", "EpsId", "FechaContratacion", "Nombres", "Telefono" },
                values: new object[,]
                {
                    { 1, "Escalante", 1, 1, 1, "Cra 33 #48-3", 1, new DateTime(2011, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jorge", "3294902231" },
                    { 2, "López", 2, 2, 2, "Cra 18 #45-6", 2, new DateTime(2015, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "María", "3209876543" },
                    { 3, "Perez", 3, 3, 3, "Av. 3 #8-15", 3, new DateTime(2019, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan", "3101234567" }
                });

            migrationBuilder.InsertData(
                table: "venta",
                columns: new[] { "VentaId", "EmpleadoId", "FechaVenta", "MedicamentoId", "PacienteId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 2, 2, new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2 },
                    { 3, 3, new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3 }
                });

            migrationBuilder.InsertData(
                table: "medicamento_venta",
                columns: new[] { "MedicamentoVentaId", "CantidadVendida", "MedicamentoId", "PrecioVenta", "VentaId" },
                values: new object[,]
                {
                    { 1, 200, 1, 29383.29m, 1 },
                    { 2, 1000, 2, 4583.29m, 2 },
                    { 3, 50, 3, 57893.29m, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ciudad_DepartamentoId",
                table: "ciudad",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_MedicamentoId",
                table: "Compra",
                column: "MedicamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_ProveedorId",
                table: "Compra",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_departamento_PaisId",
                table: "departamento",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_ArlId",
                table: "Empleado",
                column: "ArlId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_CargoId",
                table: "Empleado",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_CiudadId",
                table: "Empleado",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_EpsId",
                table: "Empleado",
                column: "EpsId");

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_ProveedorId",
                table: "medicamento",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_venta_MedicamentoId",
                table: "medicamento_venta",
                column: "MedicamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_venta_VentaId",
                table: "medicamento_venta",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_refresh_token_UsuarioId",
                table: "refresh_token",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_table_name_CompraId",
                table: "table_name",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_table_name_MedicamentoId",
                table: "table_name",
                column: "MedicamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_Email",
                table: "usuario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_RolId",
                table: "usuario",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_Username",
                table: "usuario",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_venta_EmpleadoId",
                table: "venta",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_venta_MedicamentoId",
                table: "venta",
                column: "MedicamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_venta_PacienteId",
                table: "venta",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medicamento_venta");

            migrationBuilder.DropTable(
                name: "refresh_token");

            migrationBuilder.DropTable(
                name: "table_name");

            migrationBuilder.DropTable(
                name: "venta");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "paciente");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "medicamento");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "arl");

            migrationBuilder.DropTable(
                name: "ciudad");

            migrationBuilder.DropTable(
                name: "eps");

            migrationBuilder.DropTable(
                name: "proveedor");

            migrationBuilder.DropTable(
                name: "departamento");

            migrationBuilder.DropTable(
                name: "pais");
        }
    }
}
