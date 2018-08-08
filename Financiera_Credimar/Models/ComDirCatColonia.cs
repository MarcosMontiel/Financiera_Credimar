using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financiera_Credimar.Models
{
    public class ComDirCatColonia
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Valor { get; set; }

        public int FKComDirCatMunicipio { get; set; }
        [ForeignKey("FKComDirCatMunicipio")]
        public ComDirCatMunicipio ComDirCatMunicipio { get; set; }
    }
}