using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SiMed.Models;

namespace SiMed.Controllers
{
    public class AgendamentosController : Controller
    {
        private SiMedBDContext db = new SiMedBDContext();

        // GET: Agendamentos
        public ActionResult Index()
        {
            var agendamentos = db.Agendamentos.Include(a => a.Medico).Include(a => a.Pessoa);
            return View(agendamentos.ToList());
        }

        // GET: Agendamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agendamento agendamento = db.Agendamentos.Find(id);
            if (agendamento == null)
            {
                return HttpNotFound();
            }
            return View(agendamento);
        }

        // GET: Agendamentos/Create
        public ActionResult Create()
        {
            ViewBag.IDMedico = new SelectList(db.Medicos, "IDMedico", "CRM");
            ViewBag.CPFPessoa = new SelectList(db.Pessoas, "CPF", "Nome");
            return View();
        }

        // POST: Agendamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAgendamento,IDMedico,CPFPessoa,DhAgendamento,Situacao")] Agendamento agendamento)
        {
            if (ModelState.IsValid)
            {
                db.Agendamentos.Add(agendamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDMedico = new SelectList(db.Medicos, "IDMedico", "CRM", agendamento.IDMedico);
            ViewBag.CPFPessoa = new SelectList(db.Pessoas, "CPF", "Nome", agendamento.CPFPessoa);
            return View(agendamento);
        }

        // GET: Agendamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agendamento agendamento = db.Agendamentos.Find(id);
            if (agendamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDMedico = new SelectList(db.Medicos, "IDMedico", "CRM", agendamento.IDMedico);
            ViewBag.CPFPessoa = new SelectList(db.Pessoas, "CPF", "Nome", agendamento.CPFPessoa);
            return View(agendamento);
        }

        // POST: Agendamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAgendamento,IDMedico,CPFPessoa,DhAgendamento,Situacao")] Agendamento agendamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agendamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDMedico = new SelectList(db.Medicos, "IDMedico", "CRM", agendamento.IDMedico);
            ViewBag.CPFPessoa = new SelectList(db.Pessoas, "CPF", "Nome", agendamento.CPFPessoa);
            return View(agendamento);
        }

        // GET: Agendamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agendamento agendamento = db.Agendamentos.Find(id);
            if (agendamento == null)
            {
                return HttpNotFound();
            }
            return View(agendamento);
        }

        // POST: Agendamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agendamento agendamento = db.Agendamentos.Find(id);
            db.Agendamentos.Remove(agendamento);
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
