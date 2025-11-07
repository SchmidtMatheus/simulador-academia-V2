using SimuladorAcademia.Aplicacao.DTOs;
using SimuladorAcademia.Dominio.Entidades;

namespace SimuladorAcademia.Aplicacao.Mapeadores
{
    public static class AlunoMapeador
    {
        public static AlunoDTO ParaDTO(this Aluno aluno)
        {
            return new AlunoDTO
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                Email = aluno.Email,
                Telefone = aluno.Telefone,
                IsAtivo = aluno.IsAtivo,
                NomeDoTipoDePlano = aluno.TipoDePlano?.Nome ?? "N/A"
            };
        }

        public static List<AlunoDTO> ParaDTO(this IEnumerable<Aluno> alunos)
        {
            return alunos.Select(a => a.ParaDTO()).ToList();
        }
    }
}
