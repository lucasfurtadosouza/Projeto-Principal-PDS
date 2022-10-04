using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_PDS.DataBase;
using MySql.Data.MySqlClient;
namespace Projeto_PDS.Models
{
    public class FuncionarioDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Funcionario funcionario)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "INSERT Into Funcionario Values " +

                    "(null, @nome, @email, @cpf, @telefone, @rua, @numero, @bairro, @rg, @data, @carteira, @salario," +
                    "null, null)";

                comando.Parameters.AddWithValue("@nome", funcionario.Nome);
                comando.Parameters.AddWithValue("@email", funcionario.Email);
                comando.Parameters.AddWithValue("@cpf", funcionario.Cpf);
                comando.Parameters.AddWithValue("@telefone", funcionario.Telefone);
                comando.Parameters.AddWithValue("@rua", funcionario.Rua);
                comando.Parameters.AddWithValue("@numero", funcionario.Numero);
                comando.Parameters.AddWithValue("@bairro", funcionario.Bairro);
                comando.Parameters.AddWithValue("@rg", funcionario.Rg);
                comando.Parameters.AddWithValue("@data", funcionario.DataNasc?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@carteira", funcionario.CarteiraDeTrabalho);
                comando.Parameters.AddWithValue("@salario", funcionario.Salario);
                //comando.Parameters.AddWithValue("@foto", funcionario.Foto);
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
        /*public void Insert2(Funcionario funcionario)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "INSERT Into Funcionario Value " +

                    "(null, @nome, null, null, null, null, null, null, null, null, null, null, null," +
                    "null)";

                comando.Parameters.AddWithValue("@nome", funcionario.Nome);
               
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
        }*/

        public List<Funcionario> List()
        {
            try
            {
                List<Funcionario> list = new List<Funcionario>();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM Funcionario";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    var funcionario = new Funcionario();
                    funcionario.Id = reader.GetInt32("id_fun");
                    funcionario.Nome= Helpers.DAOHelper.GetString(reader, "nome_fun");
                    funcionario.Email = Helpers.DAOHelper.GetString(reader, "email_fun");
                    funcionario.Cpf = Helpers.DAOHelper.GetString(reader, "cpf_fun");
                    funcionario.Telefone = Helpers.DAOHelper.GetString(reader, "telefone_fun");
                    funcionario.Rua = Helpers.DAOHelper.GetString(reader, "rua_fun");
                    funcionario.Numero = Convert.ToInt32(Helpers.DAOHelper.GetString(reader, "numero_fun"));
                    funcionario.Bairro = Helpers.DAOHelper.GetString(reader, "bairro_fun");
                    funcionario.Rg = Helpers.DAOHelper.GetString(reader, "rg_fun");
                    funcionario.DataNasc = Convert.ToDateTime(Helpers.DAOHelper.GetString(reader, "data_nasc_fun"));
                    //funcionario.Sexo = Helpers.DAOHelper.GetString(reader, "sexo_fun");
                    funcionario.CarteiraDeTrabalho = Helpers.DAOHelper.GetString(reader, "carteira_de_trabalho_fun");
                    funcionario.Salario = Convert.ToDouble(Helpers.DAOHelper.GetString(reader, "salario_fun"));
                    funcionario.Foto = Helpers.DAOHelper.GetString(reader, "foto_fun");
                

                    list.Add(funcionario);
                }
                reader.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Funcionario funcionario)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "DELETE FROM Funcionario WHERE id_fun = @id";
                comando.Parameters.AddWithValue("@id", funcionario.Id);
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
        public void Update(Funcionario funcionario)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "UPDATE Funcionario SET " +
                    "nome_fun = @nome, email_fun = @email, cpf_fun = @cpf, telefone_fun = @telefone, rua_fun = @rua, numero_fun = @numero, bairro_fun = @bairro,rg_fun = @rg ,data_nasc_fun = @data, carteira_de_trabalho_fun = @carteira, salario_fun = @salario," +
                    " foto_fun = null" +
                    "WHERE id_fun = @id";


                comando.Parameters.AddWithValue("@nome", funcionario.Nome);
                comando.Parameters.AddWithValue("@email", funcionario.Email);
                comando.Parameters.AddWithValue("@cpf", funcionario.Cpf);
                comando.Parameters.AddWithValue("@telefone", funcionario.Telefone);
                comando.Parameters.AddWithValue("@rua", funcionario.Rua);
                comando.Parameters.AddWithValue("@numero", funcionario.Numero);
                comando.Parameters.AddWithValue("@bairro", funcionario.Bairro);
                comando.Parameters.AddWithValue("@rg", funcionario.Rg);
                comando.Parameters.AddWithValue("@data", funcionario.DataNasc?.ToString("yyyy-MM-dd"));
                //comando.Parameters.AddWithValue("@sexo", funcionario.Sexo);
                comando.Parameters.AddWithValue("@carteira", funcionario.CarteiraDeTrabalho);
                comando.Parameters.AddWithValue("@salario", funcionario.Salario);
                //comando.Parameters.AddWithValue("@foto", funcionario.Foto);



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
