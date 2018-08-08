using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financiera_Credimar.Models
{
    public class VenArticuloPrestamo
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public decimal PrecioArticulo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public DateTime FechaVenta { get; set; }

        public int FKEmpEmpleado { get; set; }
        [ForeignKey("FKEmpEmpleado")]
        public EmpEmpleado EmpEmpleado { get; set; }

        public int FKPreSolicitudPrestamo { get; set; }
        [ForeignKey("FKPreSolicitudPrestamo")]
        public PreSolicitudPrestamo PreSolicitudPrestamo { get; set; }

        public int FKVenCatEstadoVenta { get; set; }
        [ForeignKey("FKVenCatEstadoVenta")]
        public VenCatEstadoVenta VenCatEstadoVenta { get; set; }
    }
}