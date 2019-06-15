using AngelinaPrj.Models;
using AngelinaPrj.Utils;
using AngelinaPrj.ViewModel;
using System;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace AngelinaPrj.Controllers
{
    public class AutenticacaoController : Controller
    {
        private PrjContext db = new PrjContext();

        // GET: Autenticacao/Cadastrar
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: Autenticacao/Cadastrar
        [HttpPost]
        public ActionResult Cadastrar(CadastroViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewmodel);
            }

            if (db.Usuarios.Count(u => u.Email == viewmodel.Email) > 0)
            {
                ModelState.AddModelError("Email", "Esse já está cadastrado !");
                return View(viewmodel);
            }

            if (db.Salas.Count(s => s.CodigoSala == viewmodel.CodigoSala) == 0)
            {
                ModelState.AddModelError("CodigoSala", "Esta sala não existe, você é meu aluno? ");
                return View(viewmodel);
            }
            
            Usuario novoUsuario = new Usuario
            {
                Nome = viewmodel.Nome,
                Email = viewmodel.Email,
                DataNascimento = Convert.ToDateTime(viewmodel.DataNascimento),
                Senha = Hash.GerarHash(viewmodel.Senha)
            };

            db.Usuarios.Add(novoUsuario);
            db.SaveChanges();

            var queryAluno =
                (from Usuario in db.Usuarios
                 where Usuario.Email == viewmodel.Email
                 select new { Usuario.UsuarioId }).Single();

            var CodAluno = queryAluno.UsuarioId;

            var queryCodSala = 
                (from Salas in db.Salas
                          where Salas.CodigoSala == viewmodel.CodigoSala
                          select new { Salas.SalaId}).Single();

            var CodSala = queryCodSala.SalaId;

            Aluno_Sala aluno_Sala = new Aluno_Sala
            {
                UsuarioId = CodAluno,
                SalaId = CodSala                
            };

            db.Alunos_Sala.Add(aluno_Sala);

            db.SaveChanges();

            TempData["Mensagem"] = "Cadastro realizado com sucesso. Efetue login !";

            return RedirectToAction("Login");
        }

        public ActionResult Login(string ReturnUrl)
        {
            var viewmodel = new LoginViewModel
            {
                UrlRetorno = ReturnUrl
            };

            return View(viewmodel);
        }

        //POST: Autenticacao/Login
        [HttpPost]
        public ActionResult Login(LoginViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewmodel);
            }

            var usuario = db.Usuarios.FirstOrDefault(u => u.Email == viewmodel.Email);

            if (usuario == null)
            {
                ModelState.AddModelError("Email", "Email incorreto");
                return View(viewmodel);
            }

            if (usuario.Senha != Hash.GerarHash(viewmodel.Senha))
            {
                ModelState.AddModelError("Senha", "Senha incorreta");
                return View(viewmodel);
            }

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim("Email", usuario.Email),
                new Claim(ClaimTypes.Role, usuario.Tipo.ToString())
            }, "ApplicationCookie");

            Request.GetOwinContext().Authentication.SignIn(identity);

            if (!String.IsNullOrWhiteSpace(viewmodel.UrlRetorno) || Url.IsLocalUrl(viewmodel.UrlRetorno))
                return Redirect(viewmodel.UrlRetorno);
            else if (User.IsInRole("Professor"))
            {
                return RedirectToAction("Index", "Painel");
            }
            else if (User.IsInRole("Aluno"))
            {
                return RedirectToAction("Mensagens", "Perfil");
            }
            else
            {
                return View(viewmodel);
            }
        }

        //GET: Autenticacao/Logout
        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }
    }
}