using AngelinaPrj.Models;
using AngelinaPrj.ViewModel;
using System.Web.Mvc;
using System;
using System.Linq;
using System.Data.Entity;
using System.Net;

namespace AngelinaPrj.Controllers
{


    public class PainelController : Controller
    {
        private PrjContext db = new PrjContext();
        
        // GET: Painel
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Escolas.ToList());
        }

        //GET: Painel/CadastrarEscola
        [Authorize]
        public ActionResult CadastrarEscola()
        {
            return View();
        }

        //POST: Painel/CadastrarEscola
        [HttpPost]
        public ActionResult CadastrarEscola(CadastroEscolaViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewmodel);
            }

            if (db.Escolas.Count(u => u.Nome == viewmodel.Nome) > 0)
            {
                ModelState.AddModelError("Nome", "Esta escola já está cadastrada");
                return View(viewmodel);

            }

            Escola novaEscola = new Escola
            {
                Nome = viewmodel.Nome,
                Cidade = viewmodel.Cidade
            };

            db.Escolas.Add(novaEscola);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //GET: Painel/EditarEscola
        [Authorize]
        public ActionResult EditarEscola(int? EscolaId)
        {
            if (EscolaId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Escola escola = db.Escolas.Find(EscolaId);

            if (escola == null)
            {
                return HttpNotFound();
            }

            return View(escola);
        }

        //POST: Painel/EditarEscola
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarEscola([Bind(Include = "EscolaId,Nome,Cidade")]Escola escola)
        {
            if (!ModelState.IsValid)
            {
                return View(escola);
            }

            db.Entry(escola).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}