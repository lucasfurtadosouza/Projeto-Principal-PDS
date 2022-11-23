using MySql.Data.MySqlClient;
using Projeto_PDS.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_PDS.Models;

namespace Projeto_PDS.Models
{
    public class CompraDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Compra compra)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "CALL InserirCompra(@valor, @dataVenda, @horaVenda, @forma_pagamento, @status, @funcionario, @fornecedor)";

                comando.Parameters.AddWithValue("@valor", compra.Valor);
                comando.Parameters.AddWithValue("@dataVenda", compra.Data);
                comando.Parameters.AddWithValue("@horaVenda", compra.Hora);
                comando.Parameters.AddWithValue("@forma_pagamento", compra.FormaPagamento);
                comando.Parameters.AddWithValue("@status", compra.Status);
                comando.Parameters.AddWithValue("@funcionario", compra.Funcionario.Id);
                comando.Parameters.AddWithValue("@fornecedor", compra.Fornecedor.Id);

                var result = comando.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("A compra não foi realizada. Verifique e tente novamente.");

                comando.CommandText = "SELECT LAST_INSERT_ID();";
                MySqlDataReader reader = comando.ExecuteReader();
                reader.Read();

                //Pagamento pagamento = new Pagamento();
                //pagamento = _pagamento ;//pagamento.Id 
                int IdVen = reader.GetInt32("LAST_INSERT_ID()");

                reader.Close();

                InsertItens(IdVen, compra.Itens);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void InsertItens(int compraId, List<CompraItem> itens)
        {
            foreach (CompraItem item in itens)
            {
                var comando = _conn.Query();
                comando.CommandText = "CALL InserirCompraProduto(@quantidade, @valor, @valor_total, @produto, @compra)";

                comando.Parameters.AddWithValue("@quantidade", item.Quantidade);
                comando.Parameters.AddWithValue("@valor", item.Valor);
                comando.Parameters.AddWithValue("@valor_total", item.ValorTotal);
                comando.Parameters.AddWithValue("@produto", item.Produto.Id);
                comando.Parameters.AddWithValue("@compra", compraId);

                var result = comando.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Os itens da compra não foram adicionados. Verifique e tente novamente.");
            }
        }
        /*private void InsertRecebimento(int vendaId, Recebimento recebimento)
        {

            try
            {
                var comando = _conn.Query();

                comando.CommandText = "CALL InserirRecebimento(@valor, @dataRecebimento, @hora, @descricao, @status, @parcelamento, @formaPagamento, @idVenda, @Caixa);";

                comando.Parameters.AddWithValue("@valor", recebimento.Valor);
                comando.Parameters.AddWithValue("@dataRecebimento", recebimento.Data);
                comando.Parameters.AddWithValue("@hora", recebimento.Hora);
                comando.Parameters.AddWithValue("@descricao", recebimento.Descricao);
                comando.Parameters.AddWithValue("@status", recebimento.Status);
                comando.Parameters.AddWithValue("@parcelamento", recebimento.Parcelamento);
                comando.Parameters.AddWithValue("@formaPagamento", recebimento.FormaPagamento);
                comando.Parameters.AddWithValue("@idVenda", vendaId);
                comando.Parameters.AddWithValue("@Caixa", recebimento.Caixa.Id);

                var result = comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/
        public void CancelarVenda(Venda venda)
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
