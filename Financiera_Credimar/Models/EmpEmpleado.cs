using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financiera_Credimar.Models
{
    public class EmpEmpleado
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string ClaveEmpleado { get; set; }

        [Required]
        public DateTime FechaAlta { get; set; }

        [Required]
        [MaxLength(13)]
        public string Rfc { get; set; }

        [Required]
        [MaxLength(11)]
        public string NoImms { get; set; }

        public int FKComPersona { get; set; }
        [ForeignKey("FKComPersona")]
        public ComPersona ComPersona { get; set; }

        public int FKComCatSucursal { get; set; }
        [ForeignKey("FKComCatSucursal")]
        public ComCatSucursal ComCatSucursal { get; set; }

        public int FKEmpCatPuesto { get; set; }
        [ForeignKey("FKEmpCatPuesto")]
        public EmpCatPuesto EmpCatPuesto { get; set; }

        public int FKEmpCatEstadoTemporal { get; set; }
        [ForeignKey("FKEmpCatEstadoTemporal")]
        public EmpCatEstadoTemporal EmpCatEstadoTemporal { get; set; }

        public int FKEmpCatEstadoFinal { get; set; }
        [ForeignKey("FKEmpCatEstadoFinal")]
        public EmpCatEstadoFinal EmpCatEstadoFinal { get; set; }

        public DateTime FechaBaja { get; set; }
    }
}