using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AngelinaPrj.ViewModel
{
    public class LoginViewModel
    {
        [HiddenInput]
        public string UrlRetorno { get; set; }

        [Required(ErrorMessage = "Informe o email")]
        [MaxLength(50, ErrorMessage = "O email deve ter até 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6" + " caracteres")]
        public string Senha { get; set; }
    }
}