using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_PDS.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double ValorCompra { get; set; }
        public double ValorVenda { get; set; }
        public int Estoque { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }

        private bool _selected = false;
        public bool IsSelected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
            }
        }

    }
}
