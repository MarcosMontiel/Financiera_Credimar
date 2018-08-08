using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financiera_Credimar.Models
{
    public class PrePlantillaPagos
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int NoPago { get; set; }

        [Required]
        public decimal PagoRequerido { get; set; }

        [Required]
        public DateTime FechaRequeridaPago { get; set; }

        public decimal PagoRealizado { get; set; }

        public DateTime FechaPago { get; set; }

        public int FKPreSolicitudPrestamo { get; set; }
        [ForeignKey("FKPreSolicitudPrestamo")]
        public PreSolicitudPrestamo PreSolicitudPrestamo { get; set; }

        public int FKPreCatEstadoPago { get; set; }
        [ForeignKey("FKPreCatEstadoPago")]
        public PreCatEstadoPago PreCatEstadoPago { get; set; }
    }
}