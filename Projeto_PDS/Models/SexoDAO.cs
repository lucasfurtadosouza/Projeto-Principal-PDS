using MySql.Data.MySqlClient;
using Projeto_PDS.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_PDS.Models
{
    public class SexoDAO
    {
        private static Conexao _conn = new Conexao();
        public List<Sexo> List()
        {
            try
            {
                List<Sexo> list = new List<Sexo>();

                var query = _conn.Query();
                query.CommandText = "CALL ListarSexo()";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    var sexo = new Sexo();
                    sexo.Id = reader.GetInt32("id_sex");
                    sexo.Nome = Helpers.DAOHelper.GetString(reader, "tipo_sex");

                    list.Add(sexo);
                }
                reader.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
