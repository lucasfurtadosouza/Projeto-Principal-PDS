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

        public void Insert(Despesa despesa)
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Despesa> List()
        {
            try
            {
                List<Despesa> list = new List<Despesa>();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM Despesa";

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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
