using AngelinaPrj.Models;
using AngelinaPrj.Utils;
using AngelinaPrj.ViewModel;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;

namespace AngelinaPrj.Controllers
{

    [Authorize]
    public class PerfilController : Controller
    {
        private PrjContext db = new PrjContext();

        // GET: Perfil/AlterarSenha
        public ActionResult AlterarSenha()
        {
            return View();
        }

        //POST: Perfil/AlterarSenha
        [HttpPost]
        public ActionResult AlterarSenha(AlteraSenhaViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var identity = User.Identity as ClaimsIdentity;
            var login = identity.Claims.FirstOrDefault(c => c.Type == "Email").Value;

            var usuario = db.Usuarios.FirstOrDefault(u => u.Email == login);

            if (Hash.GerarHash(viewmodel.SenhaAtual) != usuario.Senha)
            {
                ModelState.AddModelError("SenhaAtual", "Senha incorreta");
                return View();
            }

            usuario.Senha = Hash.GerarHash(viewmodel.NovaSenha);
            db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            TempData["Mensagem"] = "Senha alterada com sucesso";

            return RedirectToAction("Index", "Painel");
        }

        //GET: Perfil/Mensagens
        public ActionResult Mensagens()
        {
            return View();
        }

    }
}