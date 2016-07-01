using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SiMed.Models;
using SiMed.Services;
using SiMed.Seguranca;

namespace SiMed.Controllers
{   
    [Autorizador]
    public class DisponibilidadesController : Controller
    {
        private SiMedBDContext db = new SiMedBDContext();
        private DisponibilidadeService service = new DisponibilidadeService();

        // GET: Disponibilidades
        [Autorizador(Roles = "MEDICO")]
        public ActionResult Index()
        {
            var medico = db.Medicos.FirstOrDefault(x => x.IDUsuario == ControleDeSessao.UsuarioLogado.IDUsuario);
            var disponibilidades = db.Disponibilidades.Include(d => d.Medico).Where(x => x.IDMedico == medico.IDMedico).OrderBy(d => d.Dia);
            return View(disponibilidades.ToList());
        }

        // GET: Disponibilidades/Details/5
        [Autorizador(Roles = "MEDICO")]
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Disponibilidade disponibilidade = db.Disponibilidades.Include("Medico").FirstOrDefault(d => d.IDDisponibilidade == id);

            if (disponibilidade == null)
            {
                return HttpNotFound();
            }

            return View(disponibilidade);
        }

        // GET: Disponibilidades/Create
        [Autorizador(Roles = "MEDICO")]
        public ActionResult Create()
        {
            ViewBag.IDMedico = db.Medicos.FirstOrDefault(x => x.IDUsuario == ControleDeSessao.UsuarioLogado.IDUsuario).IDMedico;
            return View();
        }

        // POST: Disponibilidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Autorizador(Roles = "MEDICO")]
        public ActionResult Create([Bind(Include = "IDMedico,Dia,InicioTurno1,FimTurno1,InicioTurno2,FimTurno2")] Disponibilidade disponibilidade)
        {
            if (ModelState.IsValid)
            {
                db.Disponibilidades.Add(disponibilidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDMedico = new SelectList(db.Medicos, "IDMedico", "Nome", disponibilidade.IDMedico);
            return View(disponibilidade);
        }

        // GET: Disponibilidades/Edit/5
        [Autorizador(Roles = "MEDICO")]
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disponibilidade disponibilidade = db.Disponibilidades.Find(id);
            if (disponibilidade == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDMedico = new SelectList(db.Medicos, "IDMedico", "Nome", disponibilidade.IDMedico);
            return View(disponibilidade);
        }

        // POST: Disponibilidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Autorizador(Roles = "MEDICO")]
        public ActionResult Edit([Bind(Include = "IDDisponibilidade,IDMedico,Dia,InicioTurno1,FimTurno1,InicioTurno2,FimTurno2")] Disponibilidade disponibilidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disponibilidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDMedico = new SelectList(db.Medicos, "IDMedico", "Nome", disponibilidade.IDMedico);
            return View(disponibilidade);
        }

        // GET: Disponibilidades/Delete/5
        [Autorizador(Roles = "MEDICO")]
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disponibilidade disponibilidade = db.Disponibilidades.Include("Medico").FirstOrDefault(d => d.IDDisponibilidade == id);
            if (disponibilidade == null)
            {
                return HttpNotFound();
            }
            return View(disponibilidade);
        }

        // POST: Disponibilidades/Delete/5
        [Autorizador(Roles = "MEDICO")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Disponibilidade disponibilidade = db.Disponibilidades.Find(id);
            db.Disponibilidades.Remove(disponibilidade);
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

        [HttpGet]
        [Autorizador(Roles = "USUARIO")]
        public JsonResult ObterDatasDisponiveis(long idMedico)
        {
            return Json(service.ObterDatasDisponiveis(idMedico), JsonRequestBehavior.AllowGet);
        }
    }
}
