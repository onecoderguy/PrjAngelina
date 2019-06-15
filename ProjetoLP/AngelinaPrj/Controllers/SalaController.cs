using AngelinaPrj.Models;
using AngelinaPrj.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngelinaPrj.Controllers
{
    [Authorize]
    public class SalaController : Controller
    {
        private PrjContext db = new PrjContext();

        // GET: Sala/
        public ActionResult Index(int ? MateriaId)
        {
            if (MateriaId == null)
            {
                return View(db.Salas.ToList());
            }
            
            return View(db.Materias_Salas.Where(s => s.MateriaId == MateriaId).ToList());
        }

        //GET: Sala/CadastrarSala
        [Authorize(Roles = "Professor")]
        public ActionResult CadastrarSala(int MateriaId)
        {
            CadastroSalaViewModel sala = new CadastroSalaViewModel
            {
                MateriaId = MateriaId
            };

            return View(sala);
        }

        //POST: Sala/CadastrarSala
        [Authorize(Roles = "Professor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarSala(CadastroSalaViewModel viewmodel, int MateriaId)
        {
            if (!ModelState.IsValid)
            {
                return View(viewmodel);
            }
                Random rand = new Random((int)DateTime.Now.Ticks);
                var CodigoSala = 0;
                CodigoSala = rand.Next(1000, 9999);

            Sala sala = new Sala
            {
                Semestre = viewmodel.Semestre,
                Situacao = viewmodel.Situacao,
                Periodo = viewmodel.Periodo,
                CodigoSala = CodigoSala                
            };

            db.Salas.Add(sala);
            db.SaveChanges();

            Materia_Sala sala_materia = new Materia_Sala
            {
                MateriaId = MateriaId,
                SalaId = sala.SalaId
            };

            db.Materias_Salas.Add(sala_materia);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}