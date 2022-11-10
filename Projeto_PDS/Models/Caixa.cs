using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_PDS.Models
{
    public class Caixa
    {
        public int Id { get; set; }
        public double SaldoInicial { get; set; }
        public double SaldoFinal { get; set; }
        public DateTime? DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }
        public DateTime? HoraAbertura { get; set; }
        public DateTime? HoraFechamento { get; set; }
        public int QuantidadePagamentos { get; set; }
        public int QuantidadeRecebimentos { get; set; }
        public string Status { get; set; }
    }
}
