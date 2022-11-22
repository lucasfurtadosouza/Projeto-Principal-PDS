using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Projeto_PDS.DataBase;

namespace Projeto_PDS.Models
{
    public class DespesaDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Despesa despesa, Pagamento _pagamento)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "CALL InserirDespesa" +
                    "(@valor, @dataVencimento, @dataPagamento, @formaPagamento, @descricao)";

                comando.Parameters.AddWithValue("@valor", despesa.Valor);
                comando.Parameters.AddWithValue("@dataVencimento", despesa.Data_Vencimento);
                comando.Parameters.AddWithValue("@dataPagamento", despesa.Data_Pagamento);
                comando.Parameters.AddWithValue("@formaPagamento", despesa.Forma_Pagamento);
                comando.Parameters.AddWithValue("@descricao", despesa.Descricao);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações");
                }

                comando.CommandText = "SELECT LAST_INSERT_ID();";
                MySqlDataReader reader = comando.ExecuteReader();
                reader.Read();

                Pagamento pagamento = new Pagamento();
                pagamento = _pagamento;
                pagamento.IdDespesa = reader.GetInt32("LAST_INSERT_ID()");

                reader.Close();

                InsertPagamento(pagamento.IdDespesa, pagamento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Despesa> List(string busca)
        {
            try
            {
                List<Despesa> list = new List<Despesa>();

                var query = _conn.Query();
                query.CommandText = "CALL ListarDespesa(@busca)";
                query.Parameters.AddWithValue("@busca", busca);

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    var despesa = new Despesa();
                    despesa.Id = reader.GetInt32("id_des");
                    despesa.Valor = Convert.ToDouble(Helpers.DAOHelper.GetString(reader, "valor_des"));
                    despesa.Data_Vencimento = Convert.ToDateTime(Helpers.DAOHelper.GetString(reader, "data_vencimento_des"));
                    despesa.Data_Pagamento  = Convert.ToDateTime(Helpers.DAOHelper.GetString(reader, "data_pagamento_des"));
                    despesa.Forma_Pagamento = Helpers.DAOHelper.GetString(reader, "forma_pagamento_des");
                    despesa.Descricao = Helpers.DAOHelper.GetString(reader, "descricao_des");               

                    list.Add(despesa);
                }
                reader.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Despesa despesa)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "CALL DeletarDespesa(@id)";
                comando.Parameters.AddWithValue("@id", despesa.Id);
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
        public void Update(Despesa despesa)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "CALL AtualizarDespesa" +
                    "(@id, @valor, @dataVencimento, @dataPagamento, @formaPagamento, @descricao)";

                comando.Parameters.AddWithValue("@id", despesa.Id);
                comando.Parameters.AddWithValue("@valor", despesa.Valor);
                comando.Parameters.AddWithValue("@dataVencimento", despesa.Data_Vencimento);
                comando.Parameters.AddWithValue("@dataPagamento", despesa.Data_Pagamento);
                comando.Parameters.AddWithValue("@formaPagamento", despesa.Forma_Pagamento);
                comando.Parameters.AddWithValue("@descricao", despesa.Descricao);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void InsertPagamento(int DespesaId, Pagamento pagamento)
        {

            try
            {
                var comando = _conn.Query();

                comando.CommandText = "CALL InserirPagamento(@valor, @dataVencimento, @hora, @descricao, @status, @parcelamento, @formaPagamento, @idDespesa, @idCaixa);";

                comando.Parameters.AddWithValue("@valor", pagamento.Valor);
                comando.Parameters.AddWithValue("@dataVencimento", pagamento.Data);
                comando.Parameters.AddWithValue("@hora", pagamento.Hora);
                comando.Parameters.AddWithValue("@descricao", pagamento.Descricao);
                comando.Parameters.AddWithValue("@status", pagamento.Status);
                comando.Parameters.AddWithValue("@parcelamento", pagamento.Parcelamento);
                comando.Parameters.AddWithValue("@formaPagamento", pagamento.FormaPagamento);
                comando.Parameters.AddWithValue("@idDespesa", DespesaId);
                comando.Parameters.AddWithValue("@idCaixa", pagamento.Caixa.Id);

                var result = comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
