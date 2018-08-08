using System.ComponentModel.DataAnnotations;

namespace Financiera_Credimar.Models
{
    public class EmpCatEstadoTemporal
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Valor { get; set; }
    }
}