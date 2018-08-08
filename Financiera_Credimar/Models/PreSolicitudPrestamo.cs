using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financiera_Credimar.Models
{
    public class PreSolicitudPrestamo
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string ClaveSolicitud { get; set; }

        [Required]
        public DateTime FechaSolicitud { get; set; }

        [Required]
        public decimal MontoSolicitado { get; set; }

        public string CodigoArticulo { get; set; }

        public int Kilates { get; set; }

        public int Gramos { get; set; }

        public decimal MontoAprobado { get; set; }

        public int FKCliCliente { get; set; }
        [ForeignKey("FKCliCliente")]
        public CliCliente CliCliente { get; set; }

        public int FKEmpEmpleado { get; set; }
        [ForeignKey("FKEmpEmpleado")]
        public EmpEmpleado EmpEmpleado { get; set; }

        public int FKPreCatArticulo { get; set; }
        [ForeignKey("FKPreCatArticulo")]
        public PreCatArticulo PreCatArticulo { get; set; }

        public int FKPreCatEstado { get; set; }
        [ForeignKey("FKPreCatEstado")]
        public PreCatEstado PreCatEstado { get; set; }

        public DateTime FechaAprobacion { get; set; }

        public DateTime FechaFin { get; set; }
    }
}