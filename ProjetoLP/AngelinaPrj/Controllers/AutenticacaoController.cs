﻿using AngelinaPrj.Models;
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

        // GET: Autenticacao
        public ActionResult Cadastrar()
        {
            return View();
        }

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

            Usuario novoUsuario = new Usuario
            {
                Nome = viewmodel.Nome,
                Email = viewmodel.Email,
                DataNascimento = viewmodel.DataNascimento,
                Senha = Hash.GerarHash(viewmodel.Senha)
            };

            db.Usuarios.Add(novoUsuario);
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
            else
                return RedirectToAction("Index", "Painel");
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }
    }
}