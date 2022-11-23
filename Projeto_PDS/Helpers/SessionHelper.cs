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

                
                string lucro = reader.GetString("lucro");

                reader.Close();

                string lucroFormatado = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", lucro);

                return lucroFormatado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
