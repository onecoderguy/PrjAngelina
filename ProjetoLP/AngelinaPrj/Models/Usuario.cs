using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AngelinaPrj.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(50)]
        public string Login { get; set; }

        [Required]
        [MaxLength(100)]
        public string Senha { get; set; }

        [Required]
        public TipoUsuario Tipo { get; set; } = TipoUsuario.Padrao;
    }
}