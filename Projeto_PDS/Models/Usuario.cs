using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_PDS.DataBase;

namespace Projeto_PDS.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Permissao { get; set; }
        public string Senha { get; set; }
        public string buscar { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
