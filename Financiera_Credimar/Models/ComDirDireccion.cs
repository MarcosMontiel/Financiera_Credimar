using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financiera_Credimar.Models
{
    public class ComDirDireccion
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Calle { get; set; }

        [Required]
        public int NumExt { get; set; }

        [Required]
        public int NumInt { get; set; }

        [Required]
        public int CP { get; set; }

        public int FKComPersona { get; set; }
        [ForeignKey("FKComPersona")]
        public ComPersona ComPersona { get; set; }

        public int FKComDirCatEstado { get; set; }
        [ForeignKey("FKComDirCatEstado")]
        public ComDirCatEstado ComDirCatEstado { get; set; }

        public int FKComDirCatMunicipio { get; set; }
        [ForeignKey("FKComDirCatMunicipio")]
        public ComDirCatMunicipio ComDirCatMunicipio { get; set; }

        public int FKComDirCatColonia { get; set; }
        [ForeignKey("FKComDirCatColonia")]
        public ComDirCatColonia ComDirCatColonia { get; set; }
    }
}