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

namespace SiMed.Controllers
{
    public class AgendamentosController : Controller
    {
        private SiMedBDContext db = new SiMedBDContext();
        private AgendamentoService service = new AgendamentoService();

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
            ViewBag.IDMedico = new SelectList(db.Medicos, "IDMedico", "Nome");
            ViewBag.CPFPessoa = new SelectList(db.Pessoas, "CPF", "Nome");
            return View();
        }

        // POST: Agendamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAgendamento,IDMedico,CPFPessoa,Data,Hora,Situacao,Classificacao")] Agendamento agendamento)
        {   
            if (agendamento.Classificacao == Classificacao.RECONSULTA && !service.TemConsultaAnterior(agendamento))
            {
                ModelState.AddModelError("Sem consulta anterior", "Só é possivel marcar reconsulta se já houver sido feita uma consulta.");
            }

            if (ModelState.IsValid && service.PodeAgendar(agendamento))
            {
                service.Agendar(agendamento);
                return RedirectToAction("Index");
            }

            ViewBag.IDMedico = new SelectList(db.Medicos, "IDMedico", "Nome", agendamento.IDMedico);
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
            ViewBag.IDMedico = new SelectList(db.Medicos, "IDMedico", "Nome", agendamento.IDMedico);
            ViewBag.CPFPessoa = new SelectList(db.Pessoas, "CPF", "Nome", agendamento.CPFPessoa);
            return View(agendamento);
        }

        // POST: Agendamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAgendamento,IDMedico,CPFPessoa,Data,Hora,Situacao,Classificacao")] Agendamento agendamento)
        {
            if (agendamento.Classificacao == Classificacao.RECONSULTA && !service.TemConsultaAnterior(agendamento))
            {
                ModelState.AddModelError("Sem consulta anterior", "Só é possivel marcar reconsulta se já houver sido feita uma consulta.");
            }

            if (ModelState.IsValid && service.PodeAgendar(agendamento))
            {
                db.Entry(agendamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDMedico = new SelectList(db.Medicos, "IDMedico", "Nome", agendamento.IDMedico);
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
