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

                comando.CommandText = "INSERT Into Caixa Value " +

                    "(null, @saldo_inicial, @saldo_final, @data_abertura, @data_fechamento, @hora_abertura, @hora_fechamento, @quantidade_pagamentos, @quantidade_recebimentos)";

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
            catch (Exception exacao)
            {
                throw exacao;
            }
        }
    }
}
