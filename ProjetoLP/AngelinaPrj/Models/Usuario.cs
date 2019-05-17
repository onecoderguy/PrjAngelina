using System;
using System.ComponentModel;
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
        public DateTime DataNascimento { get; set; } 

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Senha { get; set; }

        [Required]
        [DefaultValue(0)]
        public TipoUsuario Tipo { get; set; } = TipoUsuario.Aluno;
    }
}