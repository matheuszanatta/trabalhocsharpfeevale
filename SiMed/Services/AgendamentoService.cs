using SiMed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiMed.Services
{
    public class AgendamentoService
    {
        private SiMedBDContext db = new SiMedBDContext();

        public bool TemConsultaAnterior(Agendamento agendamento)
        {
            DateTime dataLimite = DateTime.Now.AddDays(-30);
            string cpfPessoa = agendamento.CPFPessoa;
            long idMedico = agendamento.IDMedico;

            return db.Agendamentos.Count(a => a.Classificacao == Classificacao.CONSULTA
                                           && a.CPFPessoa.Equals(cpfPessoa)
                                           && a.IDMedico == idMedico
                                           && a.Data > dataLimite
                                           && a.Situacao == Situacao.ATIVO) > 0;
        }

        public bool PodeAgendar(Agendamento agendamento)
        {
            DateTime dataAgendamento = agendamento.Data;
            TimeSpan horaAgendamento = agendamento.Hora;
            TimeSpan fimAgendamento = agendamento.HoraFimDaConsulta();

            Disponibilidade disponibilidade = db.Disponibilidades.FirstOrDefault(d => d.IDMedico == agendamento.IDMedico && d.Dia == dataAgendamento);
            IList<Agendamento> agendamentos = db.Agendamentos.Where(a => a.Data == dataAgendamento && a.IDMedico == agendamento.IDMedico && a.Situacao == Situacao.ATIVO).ToList();

            bool temDisponibilidade = ((horaAgendamento >= disponibilidade.InicioTurno1 && fimAgendamento <= disponibilidade.FimTurno1) || (horaAgendamento >= disponibilidade.InicioTurno2 && fimAgendamento <= disponibilidade.FimTurno2));
            bool agendamentoConflitante = agendamentos.Count(a => (horaAgendamento >= a.Hora && horaAgendamento < a.HoraFimDaConsulta()) || (fimAgendamento > a.Hora && fimAgendamento <= a.HoraFimDaConsulta())) > 0;

            return temDisponibilidade && !agendamentoConflitante;
        }

        public void Agendar(Agendamento agendamento)
        {
            agendamento.Situacao = Situacao.ATIVO;
            db.Agendamentos.Add(agendamento);
            db.SaveChanges();
        }

        public IList<string> ObterHorariosOcupados(long idMedico, DateTime data)
        {
            IList<Agendamento> agendamentos = db.Agendamentos.Where(a => a.IDMedico == idMedico && a.Data == data).OrderBy(a => a.Hora).ToList();

            List<string> retorno = new List<string>();

            foreach (var agendamento in agendamentos)
            {
                retorno.Add(agendamento.Hora + " - " + agendamento.HoraFimDaConsulta());
            }

            return retorno;
        }
    }
}