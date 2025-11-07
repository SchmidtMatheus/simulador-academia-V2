using SimuladorAcademia.Aplicacao.DTOs;
using SimuladorAcademia.Dominio.Entidades;

namespace SimuladorAcademia.Aplicacao.Mapeadores
{
    public static class ReservaMapeador
    {
        public static ReservaDTO ParaDTO(this Reserva reserva)
        {
            return new ReservaDTO
            {
                Id = reserva.Id,
                NomeAluno = reserva.Aluno?.Nome ?? "N/A",
                NomeAula = reserva.Aula?.TipoDeAula?.Nome ?? "N/A",
                DataAgendamento = reserva.DataAgendamento,
                Status = reserva.StatusReserva
            };
        }

        public static List<ReservaDTO> ParaDTO(this IEnumerable<Reserva> reservas)
        {
            return reservas.Select(r => r.ParaDTO()).ToList();
        }
    }
}
