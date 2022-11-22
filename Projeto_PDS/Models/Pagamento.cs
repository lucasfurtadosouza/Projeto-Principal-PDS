using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_PDS.Models
{
    public class Pagamento
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public DateTime? Data { get; set; }
        public DateTime? Hora { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public string Status { get; set; }
        public int Parcelamento { get; set; }
        public string FormaPagamento { get; set; }
        public int IdDespesa { get; set; }
        public Caixa Caixa { get; set; }
    }
}
