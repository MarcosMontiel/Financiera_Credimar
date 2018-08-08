using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financiera_Credimar.Models
{
    public class ComPersona
    {
        [Key]         public int ID { get; set; }

        [Required]         [MaxLength(50)]         public string Nombre { get; set; }

        [Required]         [MaxLength(50)]         public string APaterno { get; set; }          [Required]         [MaxLength(50)]         public string AMaterno { get; set; }          [Required]         [MaxLength(18)]         public string Curp { get; set; }          [Required]         public DateTime FechaNac { get; set; }

        public int FKComCatGenero { get; set; }         [ForeignKey("FKComCatGenero")]         public ComCatGenero ComCatGenero { get; set; }
    }
}