using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class acao
    {
        
            [Key]
            public int IdAcao { get; set; }
            [Required]
            public string selecionarProjeto { get; set; }
            [Required]
            public string adicionarAcao { get; set; }
            [Required]
            public DateTime dataHora { get; set; }
            [Required]
            public string statusAcao { get; set; }
            [Required]
            public string emailUsuario { get; set; }
            [Required]
            public int IdProjeto { get; set; }
            public projeto projeto { get; set; }
        
    }

}

