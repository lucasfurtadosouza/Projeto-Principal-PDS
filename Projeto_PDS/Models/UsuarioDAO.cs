using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_PDS.Models;
using MySql.Data.MySqlClient;
using Projeto_PDS.DataBase;

namespace Projeto_PDS.Models
{
    public class UsuarioDAO
    {
        private static Conexao _conn = new Conexao();
        public void Insert(Usuario user)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "INSERT Into usuario Value " +

                    "(null, @nome, @senha, @perm, null)";

                comando.Parameters.AddWithValue("@nome", user.Nome);
                comando.Parameters.AddWithValue("@senha", user.Senha);
                comando.Parameters.AddWithValue("@perm", user.Permissao);


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
        public List<Usuario> List()
        {
            try
            {
                List<Usuario> list = new List<Usuario>();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM Usuario";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    var user = new Usuario();
                    user.Id = reader.GetInt32("id_usu");
                    user.Nome = Helpers.DAOHelper.GetString(reader, "nome_usu");
                    user.Permissao = Helpers.DAOHelper.GetString(reader, "nivel_permissao_usu");
                    user.Senha = Helpers.DAOHelper.GetString(reader, "senha_usu");
                    user.FK_Fun = Helpers.DAOHelper.GetDouble(reader, "id_fun_fk");

                    list.Add(user);
                }
                reader.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Usuario usuario)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "DELETE FROM Usuario WHERE id_usu = @id";
                comando.Parameters.AddWithValue("@id", usuario.Id);
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
        public void Update(Usuario usuario)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "UPDATE UsuarioSET " +
                    "nome_usu = @nome, permissao_usu = @perm, senha_usu = @senha, id_fun_fk = @funcionario"+
                    "WHERE id_usu = @id";

                comando.Parameters.AddWithValue("@nome", usuario.Nome);
                comando.Parameters.AddWithValue("@perm", usuario.Permissao);
                comando.Parameters.AddWithValue("@senha", usuario.Senha);
                comando.Parameters.AddWithValue("@funcionario", usuario.FK_Fun);
             

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
