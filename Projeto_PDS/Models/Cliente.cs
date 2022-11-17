using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_PDS.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Rg { get; set; }
        public DateTime? DataNasc { get; set; }
        public Sexo Sexo { get; set; }
        public string RendaFamiliar { get; set; }
        public string Foto { get; set; }
    }
}
