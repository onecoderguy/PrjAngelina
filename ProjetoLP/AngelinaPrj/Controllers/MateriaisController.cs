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
    public class MateriaisController : Controller
    {
        private PrjContext db = new PrjContext();

        // GET: Materiais/DetalhesMaterial/
        [Authorize]
        public ActionResult DetalhesMaterial(int ? MaterialId)
        {
            if (MaterialId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Material material = db.Materiais.Find(MaterialId);

            if (material == null)
            {
                return HttpNotFound();
            }

            var exercicios = db.Exercicios.Where(m => m.MaterialId == MaterialId).ToList();

            var view = new DetalhesMaterialViewModel()
            {
                Material = material,
                Exercicios = exercicios
            };

            return View(view);
        }

        // GET: Materiais/CadastrarMaterial/
        [Authorize(Roles = "Professor")]
        public ActionResult CadastrarMaterial(int ? SalaId)
        {
            if (SalaId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            else {
                int salaId = Convert.ToInt16(SalaId);

                CadastroMaterialViewModel material = new CadastroMaterialViewModel
                {
                    SalaId = salaId
                };

                return View(material);
            }
        }

        // POST: Materiais/CadastrarMaterial/
        [Authorize(Roles = "Professor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarMaterial(HttpPostedFileBase file, CadastroMaterialViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewmodel);
            }

            if (db.Materiais.Count(m => m.Assunto == viewmodel.Assunto) > 0)
            {
                if (db.Materiais.Count(m => m.Sala.SalaId == viewmodel.SalaId) > 0)
                {
                    ModelState.AddModelError("Assunto", "Este material já existe, altere o assunto para não gerar ambiguidade.");
                    return View(viewmodel);
                }
            }

            if (file.ContentLength > 0)
            {
                var nomeArquivo = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Uploads"), nomeArquivo);

                file.SaveAs(path);

                Material material = new Material
                {
                    Resumo = viewmodel.Resumo,
                    Assunto = viewmodel.Assunto,
                    Data = DateTime.Now,
                    Descricao = viewmodel.Descricao,
                    SalaId = viewmodel.SalaId,
                    Arquivo = path
                };

                db.Materiais.Add(material);
            }
            else
            {
                Material material = new Material
                {
                    Resumo = viewmodel.Resumo,
                    Assunto = viewmodel.Assunto,
                    Data = DateTime.Now,
                    Descricao = viewmodel.Descricao,
                    SalaId = viewmodel.SalaId
                };

                db.Materiais.Add(material);
            }

            db.SaveChanges();

            var queryUltimoMaterial =
                (from m in db.Materiais
                 orderby m.MaterialId descending
                 select new { m.MaterialId }).First();


            return RedirectToAction("DetalhesMaterial", new { MaterialId = queryUltimoMaterial.MaterialId});
        }

        //GET: Materiais/DownloadMaterial/
        [Authorize]
        public FileResult DownloadMaterial(string arquivo)
        {
            var path = arquivo;

            FileStream fileStream;

            fileStream = System.IO.File.OpenRead(path);

            string contentType = "application/pdf";

            return File(fileStream, contentType);
        }

        // GET: Materiais/EditarMaterial/
        public ActionResult EditarMaterial(int? MaterialId)
        {
            if (MaterialId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Material material = db.Materiais.Find(MaterialId);

            if (material == null)
            {
                return HttpNotFound();
            }

            return View(material);
        }

        [Authorize(Roles = "Professor")]
        // POST: Materiais/EditarMaterial/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarMaterial([Bind(Include = "MaterialId,Assunto,Data,Descricao,Arquivo")] Material material)
        {
            if (ModelState.IsValid)
            {
                db.Entry(material).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(material);
        }

        // GET: Materiais/Delete/
        [Authorize(Roles = "Professor")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Materiais.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        // POST: Materiais/Delete/
        [Authorize(Roles = "Professor")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Material material = db.Materiais.Find(id);
            db.Materiais.Remove(material);
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
