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
    public class MateriaController : Controller
    {
        private PrjContext db = new PrjContext();

        // GET: Materia/
        public ActionResult Index(int ? CursoId)
        {
            if (CursoId == null)
            {
                return View(db.Materias.ToList());
            }

            return View(db.Materias.Where(m => m.CursoId == CursoId).ToList());
        }

        //GET: Materia/CadastrarMateria
        public ActionResult CadastrarMateria(int CursoId, int EscolaId)
        {
            CadastroMateriaViewModel materia = new CadastroMateriaViewModel
            {
                CursoId = CursoId
            };

            return View(materia);
        }

        //POST: Materia/CadastrarMateria
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarMateria(CadastroMateriaViewModel viewmodel, int CursoId, int EscolaId)
        {
            if (!ModelState.IsValid)
            {
                return View(viewmodel);
            }

            if (db.Materias.Count(m => m.Nome == viewmodel.Nome) > 0)
            {
                if (db.Materias.Count(m => m.CursoId == CursoId) > 0)
                {
                    ModelState.AddModelError("Nome", "Esta matéria já está cadastrada neste curso !");
                    return View(viewmodel);
                }
            }

            Materia materia = new Materia
            {
                Nome = viewmodel.Nome,
                Descricao = viewmodel.Descricao,
                Professor = viewmodel.Professor,
                CursoId = CursoId
            };

            db.Materias.Add(materia);
            db.SaveChanges();

            var queryUltimaMateria =
                (from m in db.Materias
                 orderby m.MateriaId descending
                 select new { m.MateriaId }).First();

            Curso_Materia curso_Materia = new Curso_Materia
            {
                CursoId = materia.CursoId,
                MateriaId = queryUltimaMateria.MateriaId
            };

            db.Cursos_Materias.Add(curso_Materia);
            db.SaveChanges();

            return RedirectToAction("DetalhesCurso", "Curso", new { CursoId = CursoId, EscolaId = EscolaId});
        }

        //GET: Materia/EditarMateria
        public ActionResult EditarMateria(int ? MateriaId)
        {
            if (MateriaId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Materia materia = db.Materias.Find(MateriaId);

            if (materia == null)
            {
                return HttpNotFound();
            }

            return View(materia);
        }

        //POST: Materia/EditarMateria
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarMateria([Bind(Include = "MateriaId, Nome, Descricao")]Materia materia)
        {
            if (!ModelState.IsValid)
            {
                return View(materia);
            }

            db.Entry(materia).State = EntityState.Modified;
            db.SaveChanges();

            return View(materia);
        }

        //GET: Materia/DeletarMateria
        public ActionResult Delete(int ? MateriaId, int ? CursoId)
        {
            if (MateriaId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Materia materia = db.Materias.Find(MateriaId);

            if (materia == null)
            {
                return HttpNotFound();
            }

            return View(materia);
        }

        //POST: Materia/DeletarMateria
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int MateriaId)
        {
            Materia materia = db.Materias.Find(MateriaId);
            db.Materias.Remove(materia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Materia/DetalhesMateria
        public ActionResult DetalhesMateria(int ? MateriaId)
        {
            if (MateriaId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Materia materia = db.Materias.Find(MateriaId);

            if (materia == null)
            {
                return HttpNotFound();
            }

            var salas = db.Materias_Salas.Where(m => m.MateriaId == materia.MateriaId).ToList();

            if (salas == null)
            {
                return HttpNotFound();
            }

            var viewmodel = new DetalhesMateriaViewModel
            {
                Materia = materia,
                
                Materia_Salas = salas
            };
            

            return View(viewmodel);
        }
    }
}