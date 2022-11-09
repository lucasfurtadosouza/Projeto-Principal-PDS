using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Projeto_PDS.DataBase;

namespace Projeto_PDS.Models
{
    public class VendaDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Venda venda)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "CALL InserirVenda(@valor, @dataVenda, @horaVenda, @forma_pagamento, @funcionario, @cliente)";

                comando.Parameters.AddWithValue("@valor", venda.Valor);
                comando.Parameters.AddWithValue("@dataVenda ", venda.Data);
                comando.Parameters.AddWithValue("@horaVenda ", venda.Hora);
                comando.Parameters.AddWithValue("@forma_pagamento", venda.FormaPagamento);
                comando.Parameters.AddWithValue("@funcionario", venda.Funcionario.Id);
                comando.Parameters.AddWithValue("@cliente", venda.Cliente.Id);

                var result = comando.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("A venda não foi realizada. Verifique e tente novamente.");

                long VendaId = comando.LastInsertedId;

                InsertItens(VendaId, venda.Itens);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InsertItens(long vendaId, List<VendaItem> itens)
        {

            foreach (VendaItem item in itens)
            {
                var comando = _conn.Query();
                comando.CommandText = "CALL InserirVendaProduto(@quantidade, @valor, @valor_total, @venda, @produto)";

                comando.Parameters.AddWithValue("@quantidade", item.Quantidade);
                comando.Parameters.AddWithValue("@valor", item.Valor);
                comando.Parameters.AddWithValue("@valor_total", item.ValorTotal);
                comando.Parameters.AddWithValue("@venda", vendaId);
                comando.Parameters.AddWithValue("@produto", item.Produto.Id);

                var result = comando.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Os itens da venda não foram adicionados. Verifique e tente novamente.");
            }
        }
        public void Delete(Venda venda)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "CALL DeletarVenda(@id)";
                comando.Parameters.AddWithValue("@id", venda.Id);
                var resultado = comando.ExecuteNonQuery();
                if (resultado == 0)
                {
                    throw new Exception("Ocorreram problemas ao salvar as informações");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
