﻿using AngelinaPrj.Models;
using AngelinaPrj.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var listaSalas = new List<Materia_Sala>();
            listaSalas = db.Materias_Salas.Where(s => s.MateriaId == MateriaId).ToList();

            var listaMaterias = new List<Materia>();
            listaMaterias = db.Materias.ToList();

            ViewBag.Materias = listaMaterias;

            return View(listaSalas);
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

            //criar aqui as querys que procuram o nome da escola e da matéria
            //pela matéria eu consigo o curso e pelo curso eu consigo a escola

            var queryNomeMateria =
                (from nMateria in db.Materias
                 where nMateria.MateriaId == MateriaId
                 select new { nMateria.Nome }).Single();

            var queryCursoId =
                (from cId in db.Materias
                 where cId.MateriaId == MateriaId
                 select new { cId.CursoId }).Single();

            var queryEscolaId =
                (from eId in db.Cursos
                 where eId.CursoId == queryCursoId.CursoId
                 select new { eId.EscolaId }).Single();

            var queryNomeEscola =
                (from nEscola in db.Escolas
                 where nEscola.EscolaId == queryEscolaId.EscolaId
                 select new { nEscola.Nome }).Single();

            Sala sala = new Sala
            {
                Semestre = viewmodel.Semestre,
                Situacao = viewmodel.Situacao,
                Periodo = viewmodel.Periodo,
                CodigoSala = CodigoSala,
                Escola = queryNomeEscola.Nome,
                Materia = queryNomeMateria.Nome
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


        //GET Sala/SalasAluno
        public ActionResult SalasAlunoById(int UsuarioId)
        {
            var queryVerificaAluno = db.Usuarios.Where(u => u.Nome == User.Identity.Name).FirstOrDefault();

            int IdUsuarioSolicitado = queryVerificaAluno.UsuarioId;

            if (UsuarioId == IdUsuarioSolicitado)
            {
                var querySalasDoAluno = db.Alunos_Sala.AsQueryable().AsEnumerable();

                querySalasDoAluno = querySalasDoAluno.Where(s => s.UsuarioId == UsuarioId);

                return View(querySalasDoAluno);
            }

            else
            {
                return RedirectToAction("Index", "Home", null);
            }
        }

        //GET Sala/SalasAluno
        public ActionResult SalasAlunoByName(string NomeUsuario)
        {
            var queryProcuraIdUsuario = db.Usuarios.AsQueryable().Where(u => u.Nome == NomeUsuario).FirstOrDefault();

            int UsuarioId = queryProcuraIdUsuario.UsuarioId;

            return (RedirectToAction("SalasAlunoById", new { UsuarioId = UsuarioId}));
        }
    }

        
}