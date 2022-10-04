using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Projeto_PDS.DataBase;

namespace Projeto_PDS.Models
{
    public class CaixaDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Caixa caixa)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "INSERT Into Caixa Values " +

                    "(null, @saldo_inicial, @saldo_final, @data_abertura, @data_fechamento, @hora_abertura, @hora_fechamento," +
                    "@quantidade_pagamentos, @quantidade_recebimentos)";

                comando.Parameters.AddWithValue("@saldo_inicial", caixa.SaldoInicial);
                comando.Parameters.AddWithValue("@saldo_final", caixa.SaldoFinal);
                comando.Parameters.AddWithValue("@data_abertura", caixa.DataAbertura);
                comando.Parameters.AddWithValue("@data_fechamento", caixa.DataFechamento);
                comando.Parameters.AddWithValue("@hora_abertura", caixa.HoraAbertura);
                comando.Parameters.AddWithValue("@hora_fechamento", caixa.HoraFechamento);
                comando.Parameters.AddWithValue("@quantidade_pagamentos", caixa.QuantidadePagamentos);
                comando.Parameters.AddWithValue("@quantidade_recebimentos", caixa.QuantidadeRecebimentos);
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
        public List<Caixa> List()
        {
            try
            {
                List<Caixa> list = new List<Caixa>();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM Caixa";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    var caixa = new Caixa();
                    caixa.Id = reader.GetInt32("id_cai");
                    caixa.SaldoInicial = Convert.ToDouble(Helpers.DAOHelper.GetString(reader, "saldo_inicial_cai"));
                    caixa.SaldoFinal = Convert.ToDouble(Helpers.DAOHelper.GetString(reader, "saldo_final_cai"));
                    caixa.DataAbertura = Convert.ToDateTime(Helpers.DAOHelper.GetString(reader, "data_abertura_cai"));
                    caixa.DataFechamento = Convert.ToDateTime(Helpers.DAOHelper.GetString(reader, "data_fechamento_cai"));
                    caixa.HoraAbertura = Convert.ToDateTime(Helpers.DAOHelper.GetString(reader, "hora_abertura_cai"));
                    caixa.HoraFechamento = Convert.ToDateTime(Helpers.DAOHelper.GetString(reader, "hora_fechamento_cai"));
                    caixa.QuantidadePagamentos = Convert.ToInt32(Helpers.DAOHelper.GetString(reader, "quantidade_pagamentos_cai"));
                    caixa.QuantidadeRecebimentos = Convert.ToInt32(Helpers.DAOHelper.GetString(reader, "quantidade_recebimentos_cai"));

                    list.Add(caixa);
                }
                reader.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Caixa caixa)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "DELETE FROM Caixa WHERE id_cai = @id";
                comando.Parameters.AddWithValue("@id", caixa.Id);
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
        public void Update(Caixa caixa)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "UPDATE Caixa SET " +
                    "id_cai = @id," +
                    "saldo_inicial_cai = @saldo_inicial," +
                    "saldo_final_cai = @saldo_final," +
                    "data_abertura_cai = @data_abertura," +
                    "data_fechamento_cai = @data_fechamento, " +
                    "hora_abertura_cai = @hora_abertura," +
                    "hora_fechamento_cai = @hora_fechamento, " +
                    "quantidade_pagamentos_cai = @quantidade_pagamentos," +
                    "quantidade_recebimentos_cai = @quantidade_recebimentos;";

                comando.Parameters.AddWithValue("@id", caixa.Id);
                comando.Parameters.AddWithValue("@saldo_inicial", caixa.SaldoInicial);
                comando.Parameters.AddWithValue("@saldo_final", caixa.SaldoFinal);
                comando.Parameters.AddWithValue("@data_abertura", caixa.DataAbertura);
                comando.Parameters.AddWithValue("@data_fechamento", caixa.DataFechamento);
                comando.Parameters.AddWithValue("@hora_abertura", caixa.HoraAbertura);
                comando.Parameters.AddWithValue("@hora_fechamento", caixa.HoraFechamento);
                comando.Parameters.AddWithValue("@quantidade_pagamentos", caixa.QuantidadePagamentos);
                comando.Parameters.AddWithValue("@quantidade_recebimentos", caixa.QuantidadeRecebimentos);

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
