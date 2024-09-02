using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class anexo
    {
        [Key]
        public int IdAnexo { get; set; }

        [Required]
        public string PDFPlanta { get; set; }
        public byte[] PlantaPdf { get; set; }

        [Required]
        public string OrcamentoProjeto { get; set; }
        public byte[] Orcamento { get; set; }

        [Required]
        public string AnexosOutros { get; set; }
        public byte[] OutrosAnexos { get; set; }

        [Required]
        public string Assinatura { get; set; }
        public byte[] AssinaturaPdf { get; set; }

        [NotMapped]
        public IFormFile formFile { get; set; }

        [Required]
        public int IdProjeto { get; set; }
        public projeto projeto { get; set; }
    }
}
