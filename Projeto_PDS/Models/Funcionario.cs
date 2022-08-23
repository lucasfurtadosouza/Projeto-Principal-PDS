using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_PDS.Models
{
    public class Funcionario
    {
        public int Id { get; set;}
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Rg { get; set; }
        public DateTime? DataNasc { get; set; }
        public string Sexo { get; set; }
        public string CarteiraDeTrabalho { get; set; }
        public double Salario { get; set; }
        public string Foto { get; set; }
    }
}
