using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class projeto
    {

        [Key]
        public int IdProjeto { get; set; }
        [Required]
        public string NomeProjeto { get; set; }
        [Required]
        public DateTime DataInicioProjeto { get; set; }
        [Required]
        public DateTime DataFinalProjeto { get; set; }
        [Required]
        public string Casa { get; set; }
        [Required]
        public int valorEstimado { get; set; }
        [Required]
        public DateTime AnoAprovacao { get; set; }
        [Required]
        public int NumeroAprovacao { get; set; }
        [Required]
        public string situacao { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        public usuario usuario { get; set; }
        public ICollection<anexo> anexo { get; set; }
        public ICollection<acao> acao { get; set; }


    }

}
