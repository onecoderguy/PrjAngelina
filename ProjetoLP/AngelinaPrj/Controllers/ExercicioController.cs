using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AngelinaPrj.Models;
using AngelinaPrj.ViewModel;

namespace AngelinaPrj.Controllers
{
    public class ExercicioController : Controller
    {
        private PrjContext db = new PrjContext();


        // GET: Exercicios/DetalhesExercicio/
        public ActionResult DetalhesExercicio(int ? ExercicioId)
        {
            if (ExercicioId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Exercicio exercicio = db.Exercicios.Find(ExercicioId);

            if (exercicio == null)
            {
                return HttpNotFound();
            }
            return View(exercicio);
        }

        // GET: Exercicios/CriarExercicio/
        public ActionResult CriarExercicio(int ? MaterialId)
        {
            if (MaterialId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            else
            {
                int materialId = Convert.ToInt16(MaterialId);

                CadastroExercicioViewModel exercicio = new CadastroExercicioViewModel
                {
                    MaterialId = materialId
                };

                return View(exercicio);
            }
        }

        // POST: Exercicios/CriarExercicio/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CriarExercicio(HttpPostedFileBase file, CadastroExercicioViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewmodel);
            }

            if (file.ContentLength > 0)
            {
                var nomeArquivo = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Uploads"), nomeArquivo);

                file.SaveAs(path);

                Exercicio exercicio = new Exercicio()
                {
                    Proposta = viewmodel.Proposta,
                    Arquivo = path,
                    DataDeEntrega = viewmodel.DataDeEntrega,
                    MaterialId = viewmodel.MaterialId
                };

                db.Exercicios.Add(exercicio);
            }

            else
            {
                Exercicio exercicio = new Exercicio()
                {
                    Proposta = viewmodel.Proposta,
                    DataDeEntrega = viewmodel.DataDeEntrega,
                    MaterialId = viewmodel.MaterialId
                };

                db.Exercicios.Add(exercicio);
            }
            
            db.SaveChanges();

            var queryUltimoExercicio =
               (from e in db.Exercicios
                orderby e.ExercicioId descending
                select new { e.ExercicioId }).First();


            return RedirectToAction("DetalhesMaterial", "Material", new { MaterialId = queryUltimoExercicio.ExercicioId });


        }

        // GET: Exercicios/Edit/5
        public ActionResult EditarExercicio(int? ExercicioId)
        {
            if (ExercicioId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercicio exercicio = db.Exercicios.Find(ExercicioId);
            if (exercicio == null)
            {
                return HttpNotFound();
            }
            return View(exercicio);
        }

        // POST: Exercicios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarExercicio([Bind(Include = "ExercicioId,Proposta,Arquivo,DataDeEntrega")] Exercicio exercicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exercicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exercicio);
        }

        // GET: Exercicios/Delete/
        public ActionResult Delete(int? ExercicioId)
        {
            if (ExercicioId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercicio exercicio = db.Exercicios.Find(ExercicioId);
            if (exercicio == null)
            {
                return HttpNotFound();
            }
            return View(exercicio);
        }

        // POST: Exercicios/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int ExercicioId)
        {
            Exercicio exercicio = db.Exercicios.Find(ExercicioId);
            db.Exercicios.Remove(exercicio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
