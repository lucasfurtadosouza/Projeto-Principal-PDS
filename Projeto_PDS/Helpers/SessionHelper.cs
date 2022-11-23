using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Projeto_PDS.DataBase;
using Projeto_PDS.Models;

namespace Projeto_PDS.Helpers
{
    public class SessionHelper
    {
        private static Conexao _conn = new Conexao();

        public string GetLucro()
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "Call Lucro();";
                MySqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                
                double lucro = reader.GetDouble("lucro");
                reader.Close();

                string lucroFormatado = lucro.ToString("C");

                return lucroFormatado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetItensVendidos()
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "Call ItensVendidos();";
                MySqlDataReader reader = comando.ExecuteReader();
                reader.Read();

                string Itens = reader.GetString("itensVem");
                reader.Close();

                return Itens;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetEstoque()
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "Call EstoqueDisponivel();";
                MySqlDataReader reader = comando.ExecuteReader();
                reader.Read();

                string estoque = reader.GetString("estoque");
                reader.Close();

                return estoque;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
