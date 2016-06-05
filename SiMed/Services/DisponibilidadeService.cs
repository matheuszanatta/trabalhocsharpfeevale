using SiMed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SiMed.Services
{
    public class DisponibilidadeService
    {
        private SiMedBDContext db = new SiMedBDContext();

        public List<Object> ObterDatasDisponiveis(long idMedico)
        {
            IList<Disponibilidade> disponibilidades = db.Disponibilidades.Include("Medico.Agendamentos").Where(d => d.IDMedico == idMedico).ToList();

            List<Object> retorno = new List<Object>();

            foreach (var d in disponibilidades)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("<h4>")
                       .Append("Horário do médico:")
                       .Append("<h4/>")
                       .Append("<br />")
                       .Append(d.InicioTurno1)
                       .Append(" - ")
                       .Append(d.FimTurno1)
                       .Append(" / ")
                       .Append(d.InicioTurno2)
                       .Append(" - ")
                       .Append(d.FimTurno2)
                       .Append("<br />")
                       .Append("<hr />")
                       .Append("<h4>")
                       .Append("Horarios Ocupados")
                       .Append("</h4>");

                IList<string> horariosOcupados = new AgendamentoService().ObterHorariosOcupados(d.IDMedico, d.Dia);

                foreach (var ho in horariosOcupados)
                {
                    builder.Append(ho);
                    builder.Append("<br />");
                }

                retorno.Add(new
                {
                    date = d.Dia.ToString("yyyy-MM-dd"),
                    badge = false,
                    title = d.Dia.ToString("dd/MM/yyyy"),
                    body = builder.ToString(),
                });
            }

            return retorno;
        }
    }
}