using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Financiera_Credimar.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CliCatEstadoFinal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Valor = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CliCatEstadoFinal", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CliCatEstadoTemporal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Valor = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CliCatEstadoTemporal", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ComCatGenero",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Valor = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComCatGenero", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ComCatSucursal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Valor = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComCatSucursal", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ComDirCatEstado",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Valor = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComDirCatEstado", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EmpCatEstadoFinal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Valor = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpCatEstadoFinal", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EmpCatEstadoTemporal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Valor = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpCatEstadoTemporal", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EmpCatPuesto",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Valor = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpCatPuesto", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PreCatArticulo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Valor = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreCatArticulo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PreCatEstado",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Valor = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreCatEstado", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PreCatEstadoPago",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Valor = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreCatEstadoPago", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UsuCatEstado",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Valor = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuCatEstado", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UsuCatRol",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Valor = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuCatRol", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VenCatEstadoVenta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Valor = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenCatEstadoVenta", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ComPersona",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AMaterno = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    APaterno = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Curp = table.Column<string>(type: "TEXT", maxLength: 18, nullable: false),
                    FKComCatGenero = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaNac = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComPersona", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ComPersona_ComCatGenero_FKComCatGenero",
                        column: x => x.FKComCatGenero,
                        principalTable: "ComCatGenero",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComDirCatMunicipio",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FKComDirCatEstado = table.Column<int>(type: "INTEGER", nullable: false),
                    Valor = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComDirCatMunicipio", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ComDirCatMunicipio_ComDirCatEstado_FKComDirCatEstado",
                        column: x => x.FKComDirCatEstado,
                        principalTable: "ComDirCatEstado",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpEmpleado",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClaveEmpleado = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    FKComCatSucursal = table.Column<int>(type: "INTEGER", nullable: false),
                    FKComPersona = table.Column<int>(type: "INTEGER", nullable: false),
                    FKEmpCatEstadoFinal = table.Column<int>(type: "INTEGER", nullable: false),
                    FKEmpCatEstadoTemporal = table.Column<int>(type: "INTEGER", nullable: false),
                    FKEmpCatPuesto = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaBaja = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NoImms = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    Rfc = table.Column<string>(type: "TEXT", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpEmpleado", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmpEmpleado_ComCatSucursal_FKComCatSucursal",
                        column: x => x.FKComCatSucursal,
                        principalTable: "ComCatSucursal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpEmpleado_ComPersona_FKComPersona",
                        column: x => x.FKComPersona,
                        principalTable: "ComPersona",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpEmpleado_EmpCatEstadoFinal_FKEmpCatEstadoFinal",
                        column: x => x.FKEmpCatEstadoFinal,
                        principalTable: "EmpCatEstadoFinal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpEmpleado_EmpCatEstadoTemporal_FKEmpCatEstadoTemporal",
                        column: x => x.FKEmpCatEstadoTemporal,
                        principalTable: "EmpCatEstadoTemporal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpEmpleado_EmpCatPuesto_FKEmpCatPuesto",
                        column: x => x.FKEmpCatPuesto,
                        principalTable: "EmpCatPuesto",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComDirCatColonia",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FKComDirCatMunicipio = table.Column<int>(type: "INTEGER", nullable: false),
                    Valor = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComDirCatColonia", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ComDirCatColonia_ComDirCatMunicipio_FKComDirCatMunicipio",
                        column: x => x.FKComDirCatMunicipio,
                        principalTable: "ComDirCatMunicipio",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CliCliente",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClaveCliente = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    FKCliCatEstadoFinal = table.Column<int>(type: "INTEGER", nullable: false),
                    FKCliCatEstadoTemporal = table.Column<int>(type: "INTEGER", nullable: false),
                    FKComCatSucursal = table.Column<int>(type: "INTEGER", nullable: false),
                    FKComPersona = table.Column<int>(type: "INTEGER", nullable: false),
                    FKEmpEmpleado = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaBaja = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CliCliente", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CliCliente_CliCatEstadoFinal_FKCliCatEstadoFinal",
                        column: x => x.FKCliCatEstadoFinal,
                        principalTable: "CliCatEstadoFinal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CliCliente_CliCatEstadoTemporal_FKCliCatEstadoTemporal",
                        column: x => x.FKCliCatEstadoTemporal,
                        principalTable: "CliCatEstadoTemporal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CliCliente_ComCatSucursal_FKComCatSucursal",
                        column: x => x.FKComCatSucursal,
                        principalTable: "ComCatSucursal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CliCliente_ComPersona_FKComPersona",
                        column: x => x.FKComPersona,
                        principalTable: "ComPersona",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CliCliente_EmpEmpleado_FKEmpEmpleado",
                        column: x => x.FKEmpEmpleado,
                        principalTable: "EmpEmpleado",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuUsuario",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FKEmpEmpleado = table.Column<int>(type: "INTEGER", nullable: false),
                    FKUsuCatEstado = table.Column<int>(type: "INTEGER", nullable: false),
                    FKUsuCatRol = table.Column<int>(type: "INTEGER", nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    User = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuUsuario", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UsuUsuario_EmpEmpleado_FKEmpEmpleado",
                        column: x => x.FKEmpEmpleado,
                        principalTable: "EmpEmpleado",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuUsuario_UsuCatEstado_FKUsuCatEstado",
                        column: x => x.FKUsuCatEstado,
                        principalTable: "UsuCatEstado",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuUsuario_UsuCatRol_FKUsuCatRol",
                        column: x => x.FKUsuCatRol,
                        principalTable: "UsuCatRol",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComDirDireccion",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CP = table.Column<int>(type: "INTEGER", nullable: false),
                    Calle = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    FKComDirCatColonia = table.Column<int>(type: "INTEGER", nullable: false),
                    FKComDirCatEstado = table.Column<int>(type: "INTEGER", nullable: false),
                    FKComDirCatMunicipio = table.Column<int>(type: "INTEGER", nullable: false),
                    FKComPersona = table.Column<int>(type: "INTEGER", nullable: false),
                    NumExt = table.Column<int>(type: "INTEGER", nullable: false),
                    NumInt = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComDirDireccion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ComDirDireccion_ComDirCatColonia_FKComDirCatColonia",
                        column: x => x.FKComDirCatColonia,
                        principalTable: "ComDirCatColonia",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComDirDireccion_ComDirCatEstado_FKComDirCatEstado",
                        column: x => x.FKComDirCatEstado,
                        principalTable: "ComDirCatEstado",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComDirDireccion_ComDirCatMunicipio_FKComDirCatMunicipio",
                        column: x => x.FKComDirCatMunicipio,
                        principalTable: "ComDirCatMunicipio",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComDirDireccion_ComPersona_FKComPersona",
                        column: x => x.FKComPersona,
                        principalTable: "ComPersona",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PreSolicitudPrestamo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClaveSolicitud = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CodigoArticulo = table.Column<string>(type: "TEXT", nullable: true),
                    FKCliCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    FKEmpEmpleado = table.Column<int>(type: "INTEGER", nullable: false),
                    FKPreCatArticulo = table.Column<int>(type: "INTEGER", nullable: false),
                    FKPreCatEstado = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaAprobacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaSolicitud = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Gramos = table.Column<int>(type: "INTEGER", nullable: false),
                    Kilates = table.Column<int>(type: "INTEGER", nullable: false),
                    MontoAprobado = table.Column<decimal>(type: "TEXT", nullable: false),
                    MontoSolicitado = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreSolicitudPrestamo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PreSolicitudPrestamo_CliCliente_FKCliCliente",
                        column: x => x.FKCliCliente,
                        principalTable: "CliCliente",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreSolicitudPrestamo_EmpEmpleado_FKEmpEmpleado",
                        column: x => x.FKEmpEmpleado,
                        principalTable: "EmpEmpleado",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreSolicitudPrestamo_PreCatArticulo_FKPreCatArticulo",
                        column: x => x.FKPreCatArticulo,
                        principalTable: "PreCatArticulo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreSolicitudPrestamo_PreCatEstado_FKPreCatEstado",
                        column: x => x.FKPreCatEstado,
                        principalTable: "PreCatEstado",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrePlantillaPagos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FKPreCatEstadoPago = table.Column<int>(type: "INTEGER", nullable: false),
                    FKPreSolicitudPrestamo = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaRequeridaPago = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NoPago = table.Column<int>(type: "INTEGER", nullable: false),
                    PagoRealizado = table.Column<decimal>(type: "TEXT", nullable: false),
                    PagoRequerido = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrePlantillaPagos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PrePlantillaPagos_PreCatEstadoPago_FKPreCatEstadoPago",
                        column: x => x.FKPreCatEstadoPago,
                        principalTable: "PreCatEstadoPago",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrePlantillaPagos_PreSolicitudPrestamo_FKPreSolicitudPrestamo",
                        column: x => x.FKPreSolicitudPrestamo,
                        principalTable: "PreSolicitudPrestamo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VenArticuloPrestamo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    FKEmpEmpleado = table.Column<int>(type: "INTEGER", nullable: false),
                    FKPreSolicitudPrestamo = table.Column<int>(type: "INTEGER", nullable: false),
                    FKVenCatEstadoVenta = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaVenta = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PrecioArticulo = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenArticuloPrestamo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VenArticuloPrestamo_EmpEmpleado_FKEmpEmpleado",
                        column: x => x.FKEmpEmpleado,
                        principalTable: "EmpEmpleado",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VenArticuloPrestamo_PreSolicitudPrestamo_FKPreSolicitudPrestamo",
                        column: x => x.FKPreSolicitudPrestamo,
                        principalTable: "PreSolicitudPrestamo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VenArticuloPrestamo_VenCatEstadoVenta_FKVenCatEstadoVenta",
                        column: x => x.FKVenCatEstadoVenta,
                        principalTable: "VenCatEstadoVenta",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CliCliente_FKCliCatEstadoFinal",
                table: "CliCliente",
                column: "FKCliCatEstadoFinal");

            migrationBuilder.CreateIndex(
                name: "IX_CliCliente_FKCliCatEstadoTemporal",
                table: "CliCliente",
                column: "FKCliCatEstadoTemporal");

            migrationBuilder.CreateIndex(
                name: "IX_CliCliente_FKComCatSucursal",
                table: "CliCliente",
                column: "FKComCatSucursal");

            migrationBuilder.CreateIndex(
                name: "IX_CliCliente_FKComPersona",
                table: "CliCliente",
                column: "FKComPersona");

            migrationBuilder.CreateIndex(
                name: "IX_CliCliente_FKEmpEmpleado",
                table: "CliCliente",
                column: "FKEmpEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_ComDirCatColonia_FKComDirCatMunicipio",
                table: "ComDirCatColonia",
                column: "FKComDirCatMunicipio");

            migrationBuilder.CreateIndex(
                name: "IX_ComDirCatMunicipio_FKComDirCatEstado",
                table: "ComDirCatMunicipio",
                column: "FKComDirCatEstado");

            migrationBuilder.CreateIndex(
                name: "IX_ComDirDireccion_FKComDirCatColonia",
                table: "ComDirDireccion",
                column: "FKComDirCatColonia");

            migrationBuilder.CreateIndex(
                name: "IX_ComDirDireccion_FKComDirCatEstado",
                table: "ComDirDireccion",
                column: "FKComDirCatEstado");

            migrationBuilder.CreateIndex(
                name: "IX_ComDirDireccion_FKComDirCatMunicipio",
                table: "ComDirDireccion",
                column: "FKComDirCatMunicipio");

            migrationBuilder.CreateIndex(
                name: "IX_ComDirDireccion_FKComPersona",
                table: "ComDirDireccion",
                column: "FKComPersona");

            migrationBuilder.CreateIndex(
                name: "IX_ComPersona_FKComCatGenero",
                table: "ComPersona",
                column: "FKComCatGenero");

            migrationBuilder.CreateIndex(
                name: "IX_EmpEmpleado_FKComCatSucursal",
                table: "EmpEmpleado",
                column: "FKComCatSucursal");

            migrationBuilder.CreateIndex(
                name: "IX_EmpEmpleado_FKComPersona",
                table: "EmpEmpleado",
                column: "FKComPersona");

            migrationBuilder.CreateIndex(
                name: "IX_EmpEmpleado_FKEmpCatEstadoFinal",
                table: "EmpEmpleado",
                column: "FKEmpCatEstadoFinal");

            migrationBuilder.CreateIndex(
                name: "IX_EmpEmpleado_FKEmpCatEstadoTemporal",
                table: "EmpEmpleado",
                column: "FKEmpCatEstadoTemporal");

            migrationBuilder.CreateIndex(
                name: "IX_EmpEmpleado_FKEmpCatPuesto",
                table: "EmpEmpleado",
                column: "FKEmpCatPuesto");

            migrationBuilder.CreateIndex(
                name: "IX_PrePlantillaPagos_FKPreCatEstadoPago",
                table: "PrePlantillaPagos",
                column: "FKPreCatEstadoPago");

            migrationBuilder.CreateIndex(
                name: "IX_PrePlantillaPagos_FKPreSolicitudPrestamo",
                table: "PrePlantillaPagos",
                column: "FKPreSolicitudPrestamo");

            migrationBuilder.CreateIndex(
                name: "IX_PreSolicitudPrestamo_FKCliCliente",
                table: "PreSolicitudPrestamo",
                column: "FKCliCliente");

            migrationBuilder.CreateIndex(
                name: "IX_PreSolicitudPrestamo_FKEmpEmpleado",
                table: "PreSolicitudPrestamo",
                column: "FKEmpEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_PreSolicitudPrestamo_FKPreCatArticulo",
                table: "PreSolicitudPrestamo",
                column: "FKPreCatArticulo");

            migrationBuilder.CreateIndex(
                name: "IX_PreSolicitudPrestamo_FKPreCatEstado",
                table: "PreSolicitudPrestamo",
                column: "FKPreCatEstado");

            migrationBuilder.CreateIndex(
                name: "IX_UsuUsuario_FKEmpEmpleado",
                table: "UsuUsuario",
                column: "FKEmpEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_UsuUsuario_FKUsuCatEstado",
                table: "UsuUsuario",
                column: "FKUsuCatEstado");

            migrationBuilder.CreateIndex(
                name: "IX_UsuUsuario_FKUsuCatRol",
                table: "UsuUsuario",
                column: "FKUsuCatRol");

            migrationBuilder.CreateIndex(
                name: "IX_VenArticuloPrestamo_FKEmpEmpleado",
                table: "VenArticuloPrestamo",
                column: "FKEmpEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_VenArticuloPrestamo_FKPreSolicitudPrestamo",
                table: "VenArticuloPrestamo",
                column: "FKPreSolicitudPrestamo");

            migrationBuilder.CreateIndex(
                name: "IX_VenArticuloPrestamo_FKVenCatEstadoVenta",
                table: "VenArticuloPrestamo",
                column: "FKVenCatEstadoVenta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComDirDireccion");

            migrationBuilder.DropTable(
                name: "PrePlantillaPagos");

            migrationBuilder.DropTable(
                name: "UsuUsuario");

            migrationBuilder.DropTable(
                name: "VenArticuloPrestamo");

            migrationBuilder.DropTable(
                name: "ComDirCatColonia");

            migrationBuilder.DropTable(
                name: "PreCatEstadoPago");

            migrationBuilder.DropTable(
                name: "UsuCatEstado");

            migrationBuilder.DropTable(
                name: "UsuCatRol");

            migrationBuilder.DropTable(
                name: "PreSolicitudPrestamo");

            migrationBuilder.DropTable(
                name: "VenCatEstadoVenta");

            migrationBuilder.DropTable(
                name: "ComDirCatMunicipio");

            migrationBuilder.DropTable(
                name: "CliCliente");

            migrationBuilder.DropTable(
                name: "PreCatArticulo");

            migrationBuilder.DropTable(
                name: "PreCatEstado");

            migrationBuilder.DropTable(
                name: "ComDirCatEstado");

            migrationBuilder.DropTable(
                name: "CliCatEstadoFinal");

            migrationBuilder.DropTable(
                name: "CliCatEstadoTemporal");

            migrationBuilder.DropTable(
                name: "EmpEmpleado");

            migrationBuilder.DropTable(
                name: "ComCatSucursal");

            migrationBuilder.DropTable(
                name: "ComPersona");

            migrationBuilder.DropTable(
                name: "EmpCatEstadoFinal");

            migrationBuilder.DropTable(
                name: "EmpCatEstadoTemporal");

            migrationBuilder.DropTable(
                name: "EmpCatPuesto");

            migrationBuilder.DropTable(
                name: "ComCatGenero");
        }
    }
}
