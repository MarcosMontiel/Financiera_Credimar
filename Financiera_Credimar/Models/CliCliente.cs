using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financiera_Credimar.Models
{
    public class CliCliente
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string ClaveCliente { get; set; }

        [Required]
        public DateTime FechaAlta { get; set; }

        public int FKComCatSucursal { get; set; }
        [ForeignKey("FKComCatSucursal")]
        public ComCatSucursal ComCatSucursal { get; set; }

        public int FKComPersona { get; set; }
        [ForeignKey("FKComPersona")]
        public ComPersona ComPersona { get; set; }

        public int FKEmpEmpleado { get; set; }
        [ForeignKey("FKEmpEmpleado")]
        public EmpEmpleado EmpEmpleado { get; set; }

        public int FKCliCatEstadoTemporal { get; set; }
        [ForeignKey("FKCliCatEstadoTemporal")]
        public CliCatEstadoTemporal CliCatEstadoTemporal { get; set; }

        public int FKCliCatEstadoFinal { get; set; }
        [ForeignKey("FKCliCatEstadoFinal")]
        public CliCatEstadoFinal CliCatEstadoFinal { get; set; }

        public DateTime FechaBaja { get; set; }
    }
}