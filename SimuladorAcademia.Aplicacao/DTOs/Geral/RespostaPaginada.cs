namespace SimuladorAcademia.Aplicacao.DTOs.Geral
{
    public class RespostaPaginada<T>
    {
        public List<T> Itens { get; set; } = new List<T>();

        public int NumeroPagina { get; set; }
        public int TamanhoPagina { get; set; }
        public int TotalItens { get; set; }
        public int TotalPaginas => (int)Math.Ceiling((double)TotalItens / TamanhoPagina);
        public bool TemProximaPagina => NumeroPagina < TotalPaginas;
        public bool TemPaginaAnterior => NumeroPagina > 1;

        public RespostaPaginada(List<T> itens, int numeroPagina, int tamanhoPagina, int totalItens)
        {
            Itens = itens;
            NumeroPagina = numeroPagina;
            TamanhoPagina = tamanhoPagina;
            TotalItens = totalItens;
        }
    }
}
