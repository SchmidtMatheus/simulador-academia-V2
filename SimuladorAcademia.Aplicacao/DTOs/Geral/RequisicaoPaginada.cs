using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorAcademia.Aplicacao.DTOs.Geral
{
    public class RequisicaoPaginada
    {
        public int NumeroPagina { get; set; } = 1;
        public int TamanhoPagina { get; set; } = 10;
        public int Pular => (NumeroPagina - 1) * TamanhoPagina;
        public int Quantidade => TamanhoPagina;
    }
}
