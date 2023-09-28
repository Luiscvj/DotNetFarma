using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
<<<<<<<< HEAD:Persistence/Data/Migrations/20230924040450_InitialCreate.cs
    public partial class InitialCreate : Migration
========
    public partial class Migracionparaelseed : Migration
>>>>>>>> 1382bf47d5a22d4aecb8cd3b638cebf24e583a65:Persistence/Data/Migrations/20230927133253_Migracion para el seed.cs
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
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
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
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.UsuarioId);
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
                name: "Compra",
                columns: table => new
                {
                    CompraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaCompra = table.Column<DateTime>(type: "date", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.CompraId);
                    table.ForeignKey(
                        name: "FK_Compra_proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "proveedor",
                        principalColumn: "ProveedorId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medicamento",
                columns: table => new
                {
                    MedicamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreMedicamento = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
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
                name: "refresh_token",
                columns: table => new
                {
                    RefreshTokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime(6)", nullable: true)
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
                name: "UsuarioRoles",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRoles", x => new { x.RolId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_UsuarioRoles_rol_RolId",
                        column: x => x.RolId,
                        principalTable: "rol",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioRoles_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuario",
                        principalColumn: "UsuarioId",
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
                name: "medicamento_compra",
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
                    table.PrimaryKey("PK_medicamento_compra", x => x.MedicamentoCompraId);
                    table.ForeignKey(
                        name: "FK_medicamento_compra_Compra_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compra",
                        principalColumn: "CompraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medicamento_compra_medicamento_MedicamentoId",
                        column: x => x.MedicamentoId,
                        principalTable: "medicamento",
                        principalColumn: "MedicamentoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "empleado",
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
                    table.PrimaryKey("PK_empleado", x => x.EmpleadoId);
                    table.ForeignKey(
                        name: "FK_empleado_Cargo_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargo",
                        principalColumn: "CargoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_empleado_arl_ArlId",
                        column: x => x.ArlId,
                        principalTable: "arl",
                        principalColumn: "ArlId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_empleado_ciudad_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "ciudad",
                        principalColumn: "CiudadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_empleado_eps_EpsId",
                        column: x => x.EpsId,
                        principalTable: "eps",
                        principalColumn: "EpsId",
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
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_venta", x => x.VentaId);
                    table.ForeignKey(
                        name: "FK_venta_empleado_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "empleado",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
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

<<<<<<<< HEAD:Persistence/Data/Migrations/20230924040450_InitialCreate.cs
========
            migrationBuilder.InsertData(
                table: "Cargo",
                columns: new[] { "CargoId", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, "... Gerente", "Gerente" },
                    { 2, "... Admin", "Administrador" },
                    { 3, "... Vendedor", "Vendedor" }
                });

            migrationBuilder.InsertData(
                table: "arl",
                columns: new[] { "ArlId", "Direccion", "Email", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Calle arl 456", "arl1@gmail.com", "Arl1", "4342443324" },
                    { 2, "Calle arl 789", "arl2@gmail.com", "Arl2", "2342346563" },
                    { 3, "Calle arl 123", "arl3@gmail.com", "Arl3", "2457324355" }
                });

            migrationBuilder.InsertData(
                table: "eps",
                columns: new[] { "EpsId", "Direccion", "Email", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Calle Eps 456", "eps1@gmail.com", "Eps1", "4342443324" },
                    { 2, "Calle Eps 789", "eps2@gmail.com", "Eps2", "2342346563" },
                    { 3, "Calle Eps 123", "eps3@gmail.com", "Eps3", "2457324355" }
                });

            migrationBuilder.InsertData(
                table: "paciente",
                columns: new[] { "PacienteId", "Apellidos", "Direccion", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Perez", "Calle 123", "Juan", "555-1234" },
                    { 2, "Villamizar", "Calle 456", "Maria", "555-5678" },
                    { 3, "Garcia", "Calle 789", "Luis", "555-9012" }
                });

            migrationBuilder.InsertData(
                table: "pais",
                columns: new[] { "PaisId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Colombia" },
                    { 2, "Argentina" },
                    { 3, "Mexico" }
                });

            migrationBuilder.InsertData(
                table: "proveedor",
                columns: new[] { "ProveedorId", "Direccion", "Email", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Calle Proveedor 456", "contacto@proveedora.com", "ProveedorA", "32335232" },
                    { 2, "Calle Proveedor 789", "contacto@proveedorb.com", "ProveedorB", "67835424" },
                    { 3, "Calle Proveedor 123", "contacto@proveedorc.com", "ProveedorC", "34578724" }
                });

            migrationBuilder.InsertData(
                table: "Compra",
                columns: new[] { "CompraId", "FechaCompra", "ProveedorId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 10, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "departamento",
                columns: new[] { "DepartamentoId", "Nombre", "PaisId" },
                values: new object[,]
                {
                    { 1, "Santander", 1 },
                    { 2, "Buenos Aires", 2 },
                    { 3, "Ciudad Mexico", 3 }
                });

            migrationBuilder.InsertData(
                table: "medicamento",
                columns: new[] { "MedicamentoId", "FechaExpiracion", "Nombre", "Precio", "ProveedorId", "Stock" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paracetamol", 20.0, 1, 150 },
                    { 2, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ibuprofeno", 25.0, 2, 50 },
                    { 3, new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aspirina", 15.0, 3, 30 },
                    { 4, new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amoxicilina", 40.0, 1, 75 },
                    { 5, new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cetirizina", 10.0, 2, 110 },
                    { 6, new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Losartan", 55.0, 3, 95 },
                    { 7, new DateTime(2024, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Metformina", 60.0, 1, 180 },
                    { 8, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Atorvastatina", 45.0, 2, 200 },
                    { 9, new DateTime(2024, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clonazepam", 35.0, 3, 25 },
                    { 10, new DateTime(2025, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loratadina", 22.0, 1, 120 }
                });

            migrationBuilder.InsertData(
                table: "ciudad",
                columns: new[] { "CiudadId", "DepartamentoId", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Bucaramanga" },
                    { 2, 1, "Piedecuesta" },
                    { 3, 1, "Giron" }
                });

            migrationBuilder.InsertData(
                table: "medicamento_compra",
                columns: new[] { "MedicamentoCompraId", "CantidadComprada", "CompraId", "MedicamentoId", "PrecioCompra" },
                values: new object[,]
                {
                    { 1, 50, 1, 1, 15m },
                    { 2, 25, 2, 2, 20m },
                    { 3, 10, 3, 3, 12m },
                    { 4, 30, 4, 4, 35m },
                    { 5, 50, 5, 5, 8m },
                    { 6, 40, 6, 6, 50m },
                    { 7, 60, 7, 7, 55m },
                    { 8, 70, 8, 8, 40m },
                    { 9, 15, 9, 9, 32m },
                    { 10, 50, 10, 10, 20m }
                });

            migrationBuilder.InsertData(
                table: "empleado",
                columns: new[] { "EmpleadoId", "Apellidos", "ArlId", "CargoId", "CiudadId", "Direccion", "EpsId", "FechaContratacion", "Nombres", "Telefono" },
                values: new object[,]
                {
                    { 1, "Perez", 1, 3, 1, "Calle 123", 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro", "555-1234" },
                    { 2, "Villamizar", 2, 3, 1, "Calle 123", 2, new DateTime(2019, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ana", "555-1234" },
                    { 3, "Garcia", 3, 1, 1, "Calle 123", 3, new DateTime(2018, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luis", "555-1234" },
                    { 4, "Garcia", 1, 2, 1, "Calle 123", 3, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sofia", "555-1234" }
                });

            migrationBuilder.InsertData(
                table: "venta",
                columns: new[] { "VentaId", "EmpleadoId", "FechaVenta", "PacienteId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 1, new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, 1, new DateTime(2023, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, 2, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, 2, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, 1, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, 1, new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, 2, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, 2, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "medicamento_venta",
                columns: new[] { "MedicamentoVentaId", "CantidadVendida", "MedicamentoId", "PrecioVenta", "VentaId" },
                values: new object[,]
                {
                    { 1, 2, 1, 20m, 1 },
                    { 2, 1, 2, 25m, 2 },
                    { 3, 2, 3, 15m, 2 },
                    { 4, 1, 4, 40m, 3 },
                    { 5, 1, 5, 10m, 4 },
                    { 6, 1, 6, 55m, 5 },
                    { 7, 1, 7, 60m, 6 },
                    { 8, 1, 8, 45m, 7 },
                    { 9, 1, 9, 35m, 8 },
                    { 10, 1, 10, 22m, 9 },
                    { 11, 2, 1, 20m, 10 }
                });

>>>>>>>> 1382bf47d5a22d4aecb8cd3b638cebf24e583a65:Persistence/Data/Migrations/20230927133253_Migracion para el seed.cs
            migrationBuilder.CreateIndex(
                name: "IX_ciudad_DepartamentoId",
                table: "ciudad",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_ProveedorId",
                table: "Compra",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_departamento_PaisId",
                table: "departamento",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_empleado_ArlId",
                table: "empleado",
                column: "ArlId");

            migrationBuilder.CreateIndex(
                name: "IX_empleado_CargoId",
                table: "empleado",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_empleado_CiudadId",
                table: "empleado",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_empleado_EpsId",
                table: "empleado",
                column: "EpsId");

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_ProveedorId",
                table: "medicamento",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_compra_CompraId",
                table: "medicamento_compra",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_compra_MedicamentoId",
                table: "medicamento_compra",
                column: "MedicamentoId");

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
                name: "IX_usuario_Email",
                table: "usuario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_Username",
                table: "usuario",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRoles_UsuarioId",
                table: "UsuarioRoles",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_venta_EmpleadoId",
                table: "venta",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_venta_PacienteId",
                table: "venta",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medicamento_compra");

            migrationBuilder.DropTable(
                name: "medicamento_venta");

            migrationBuilder.DropTable(
                name: "refresh_token");

            migrationBuilder.DropTable(
                name: "UsuarioRoles");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "medicamento");

            migrationBuilder.DropTable(
                name: "venta");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "proveedor");

            migrationBuilder.DropTable(
                name: "empleado");

            migrationBuilder.DropTable(
                name: "paciente");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "arl");

            migrationBuilder.DropTable(
                name: "ciudad");

            migrationBuilder.DropTable(
                name: "eps");

            migrationBuilder.DropTable(
                name: "departamento");

            migrationBuilder.DropTable(
                name: "pais");
        }
    }
}
