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

                comando.CommandText = "CALL InserirCaixa" +
                    "(@saldoInicial, @saldoFinal, @dataAbertura, @horaAbertura, @qtdPagamentos, @qtdRecebimentos, @status)";

                comando.Parameters.AddWithValue("@saldoInicial", caixa.SaldoInicial);
                comando.Parameters.AddWithValue("@saldoFinal", 0);
                comando.Parameters.AddWithValue("@dataAbertura", caixa.DataAbertura);
                comando.Parameters.AddWithValue("@horaAbertura", caixa.HoraAbertura);
                comando.Parameters.AddWithValue("@qtdPagamentos", 0);
                comando.Parameters.AddWithValue("@qtdRecebimentos", 0);
                comando.Parameters.AddWithValue("@status", caixa.Status);

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
        public List<Caixa> ListCaixaAberto()
        {
            try
            {
                List<Caixa> list = new List<Caixa>();

                var query = _conn.Query();
                query.CommandText = "CALL ListarCaixaAberto();";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    var caixa = new Caixa();
                    caixa.Id = reader.GetInt32("id_cai");
                    caixa.SaldoInicial = Convert.ToDouble(Helpers.DAOHelper.GetString(reader, "saldo_inicial_cai"));
                    caixa.SaldoFinal = Convert.ToDouble(Helpers.DAOHelper.GetString(reader, "saldo_final_cai"));
                    caixa.DataAbertura = Convert.ToDateTime(Helpers.DAOHelper.GetString(reader, "data_abertura_cai"));
                    caixa.HoraAbertura = Convert.ToDateTime(Helpers.DAOHelper.GetString(reader, "hora_abertura_cai"));
                    caixa.QuantidadePagamentos = Convert.ToInt32(Helpers.DAOHelper.GetString(reader, "quantidade_pagamentos_cai"));
                    caixa.QuantidadeRecebimentos = Convert.ToInt32(Helpers.DAOHelper.GetString(reader, "quantidade_recebimentos_cai"));
                    caixa.Status = Helpers.DAOHelper.GetString(reader, "status_cai");

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
        public List<Caixa> List()
        {
            try
            {
                List<Caixa> list = new List<Caixa>();

                var query = _conn.Query();
                query.CommandText = "CALL ListarCaixa();";

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
                    caixa.Status = Helpers.DAOHelper.GetString(reader, "status_cai");

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
                comando.CommandText = "CALL DeletarCaixa(@id)";
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
        public void FecharCaixa(Caixa caixa)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "CALL FecharCaixa" +
                    "(@id, @saldoFinal, @dataFechamento, @horaFechamento, @qtdPagamentos, @qtdRecebimentos, @status)";

                comando.Parameters.AddWithValue("@id", caixa.Id);
                comando.Parameters.AddWithValue("@saldoFinal", caixa.SaldoFinal);
                comando.Parameters.AddWithValue("@dataFechamento", caixa.DataFechamento);
                comando.Parameters.AddWithValue("@horaFechamento", caixa.HoraFechamento);
                comando.Parameters.AddWithValue("@qtdPagamentos", caixa.QuantidadePagamentos);
                comando.Parameters.AddWithValue("@qtdRecebimentos", caixa.QuantidadeRecebimentos);
                comando.Parameters.AddWithValue("@status", caixa.Status);

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
