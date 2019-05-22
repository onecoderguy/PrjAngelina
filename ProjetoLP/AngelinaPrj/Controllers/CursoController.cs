using AngelinaPrj.Models;
using AngelinaPrj.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AngelinaPrj.Controllers
{
    [Authorize(Roles = "Professor")]
    public class CursoController : Controller
    {
        private PrjContext db = new PrjContext();

        // GET: Curso/
        public ActionResult Index()
        {
            return View(db.Cursos.ToList());
        }

        // GET: Curso/CadastrarCurso
        public ActionResult CadastrarCurso(int EscolaId)
        {
            CadastroCursoViewModel curso = new CadastroCursoViewModel
            {
                Escola = EscolaId
            };

            return View(curso);
        }

        //POST: Curso/CadastrarCurso
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarCurso(CadastroCursoViewModel viewmodel, int EscolaId)
        {
            if (!ModelState.IsValid)
            {
                return View(viewmodel);
            }

            if (db.Cursos.Count(u => u.Nome == viewmodel.Nome) > 0)
            {
                if (db.Cursos.Count(u => u.EscolaId == EscolaId) > 0)
                {
                    ModelState.AddModelError("Nome", "Este curso já existe nesta escola !");
                    return View(viewmodel);
                }
            }

            Curso curso = new Curso
            {
                Nome = viewmodel.Nome,
                Descricao = viewmodel.Descricao,
                EscolaId = EscolaId
            };

            db.Cursos.Add(curso);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //GET: Curso/EditarCurso
        public ActionResult EditarCurso(int ? CursoId, int EscolaId)
        {
            if (CursoId == null)
            {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Curso curso = db.Cursos.Find(CursoId);

            if (curso == null)
            {
                return HttpNotFound();
            }

            return View(curso);
        }

        //POST: Curso/EditarCurso
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarCurso([Bind(Include = "CursoId, Nome, Descricao, EscolaId, Escola, Materias")]Curso curso)
        {
            if (!ModelState.IsValid)
            {
                return View(curso);
            }

            db.Entry(curso).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //GET: Curso/DeletarCurso
        public ActionResult Delete(int ? CursoId)
        {
            if (CursoId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Curso curso = db.Cursos.Find(CursoId);

            if (curso == null)
            {
                return HttpNotFound();
            }

            return View(curso);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //POST: Curso/DeletarCurso
        public ActionResult DeleteConfirmed(int CursoId)
        {
            Curso curso = db.Cursos.Find(CursoId);
            db.Cursos.Remove(curso);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Curso/DetalhesCurso
        public ActionResult DetalhesCurso(int ? CursoId)
        {
            if (CursoId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Curso curso = db.Cursos.Find(CursoId);

            if (curso == null)
            {
                return HttpNotFound();
            }

            return View(curso);
        }
    }
}