using SimuladorAcademia.Aplicacao.DTOs;
using SimuladorAcademia.Dominio.Entidades;

namespace SimuladorAcademia.Aplicacao.Mapeadores
{
    public static class AulaMapeador
    {
        public static AulaDTO ParaDTO(this Aula aula)
        {
            return new AulaDTO
            {
                Id = aula.Id,
                TipoDeAulaNome = aula.TipoDeAula?.Nome ?? "N/A",
                DataAgendamento = aula.DataAgendamento,
                DuracaoEmMinutos = aula.DuracaoEmMinutos,
                CapacidadeMaxima = aula.CapacidadeMaxima,
                QuantidadeDeParticipantes = aula.Participantes,
                IsAtivo = aula.IsAtivo,
                IsCancelado = aula.IsCancelado,
                CriadoEm = aula.CriadoEm
            };
        }

        public static List<AulaDTO> ParaDTO(this IEnumerable<Aula> aulas)
        {
            return aulas.Select(a => a.ParaDTO()).ToList();
        }
    }
}
