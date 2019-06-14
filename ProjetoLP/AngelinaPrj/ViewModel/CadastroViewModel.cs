using System;
using System.ComponentModel.DataAnnotations;

namespace AngelinaPrj.ViewModel
{
    public class CadastroViewModel
    {
        [Required(ErrorMessage = "Informe seu nome")]
        [MaxLength(100, ErrorMessage = "O nome deve ter até 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite sua data de nascimento")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Informe seu email")]
        [MaxLength(50, ErrorMessage = "O email deve ter até 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe sua senha")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Confirme sua senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres")]
        [Compare(nameof(Senha), ErrorMessage = "A senha e a confirmação não estão iguais")]
        public string ConfirmacaoSenha { get; set; }
    }
}