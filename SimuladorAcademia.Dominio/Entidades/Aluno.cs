using System;
using System.Collections.Generic;
using System.Linq;

namespace SimuladorAcademia.Dominio.Entidades
{
    public class Aluno
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public string? Email { get; set; }
        public string? Telefone { get; set; }

        public Guid TipoDePlanoId { get; set; }
        public TipoDePlano TipoDePlano { get; set; } = null!;

        public bool IsAtivo { get; set; } = true;
        public int ContagemDeAulasMensais { get; set; } = 0;
        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
        public DateTime AtualizadoEm { get; set; } = DateTime.UtcNow;
        public DateTime? ApagadoEm { get; set; }

        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}
