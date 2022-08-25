using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_PDS.Models
{
    public class Despesa
    {
        public int Id { get; set; }
        public double Valor {get; set;}
        public  DateTime?  Data_Vencimento { get; set; }
        public DateTime? Data_Pagamento { get; set; }
        public string Forma_Pagamento { get; set; }
        public string Descricao { get; set; }



    }
}
