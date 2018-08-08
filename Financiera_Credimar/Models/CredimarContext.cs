using Microsoft.EntityFrameworkCore;

namespace Financiera_Credimar.Models
{
    public class CredimarContext : DbContext
    {
        public CredimarContext(DbContextOptions<CredimarContext> options)
            : base(options)
        {
        }

        // Módulo Común
        public DbSet<ComCatSucursal> ComCatSucursal { get; set; }

        // Módulo Persona
        public DbSet<ComCatGenero> ComCatGenero { get; set; }
        public DbSet<ComPersona> ComPersona { get; set; }

        // Módulo Dirección
        public DbSet<ComDirCatEstado> ComDirCatEstado { get; set; }
        public DbSet<ComDirCatMunicipio> ComDirCatMunicipio { get; set; }
        public DbSet<ComDirCatColonia> ComDirCatColonia { get; set; }
        public DbSet<ComDirDireccion> ComDirDireccion { get; set; }

        // Módulo Empleado
        public DbSet<EmpCatPuesto> EmpCatPuesto { get; set; }
        public DbSet<EmpCatEstadoTemporal> EmpCatEstadoTemporal { get; set; }
        public DbSet<EmpCatEstadoFinal> EmpCatEstadoFinal { get; set; }
        public DbSet<EmpEmpleado> EmpEmpleado { get; set; }

        // Módulo Cliente
        public DbSet<CliCatEstadoTemporal> CliCatEstadoTemporal { get; set; }
        public DbSet<CliCatEstadoFinal> CliCatEstadoFinal { get; set; }
        public DbSet<CliCliente> CliCliente { get; set; }

        // Módulo Usuario
        public DbSet<UsuCatEstado> UsuCatEstado { get; set; }
        public DbSet<UsuCatRol> UsuCatRol { get; set; }
        public DbSet<UsuUsuario> UsuUsuario { get; set; }

        // Módulo Préstamo
        public DbSet<PreCatEstado> PreCatEstado { get; set; }
        public DbSet<PreCatArticulo> PreCatArticulo { get; set; }
        public DbSet<PreCatEstadoPago> PreCatEstadoPago { get; set; }
        public DbSet<PreSolicitudPrestamo> PreSolicitudPrestamo { get; set; }
        public DbSet<PrePlantillaPagos> PrePlantillaPagos { get; set; }

        // Módulo Venta
        public DbSet<VenCatEstadoVenta> VenCatEstadoVenta { get; set; }
        public DbSet<VenArticuloPrestamo> VenArticuloPrestamo { get; set; }
    }
}