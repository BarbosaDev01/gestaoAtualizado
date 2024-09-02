using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required]
        public string nomeUsuario { get; set; }
        [Required]
        public string arroba { get; set; }
        [Required]
        public string status { get; set; }
        [NotMapped]
        public byte[] fotoUsuario { get; set; }
        [Required]
        public string profissao { get; set; }
        [Required]
        public string emailUsuarios { get; set; }
        public ICollection<projeto> projeto { get; set; }
    }
}
