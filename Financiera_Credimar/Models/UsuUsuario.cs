using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financiera_Credimar.Models
{
    public class UsuUsuario
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string User { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        public int FKEmpEmpleado { get; set; }
        [ForeignKey("FKEmpEmpleado")]
        public EmpEmpleado EmpEmpleado { get; set; }

        public int FKUsuCatRol { get; set; }
        [ForeignKey("FKUsuCatRol")]
        public UsuCatRol UsuCatRol { get; set; }

        public int FKUsuCatEstado { get; set; }
        [ForeignKey("FKUsuCatEstado")]
        public UsuCatEstado UsuCatEstado { get; set; }
    }
}