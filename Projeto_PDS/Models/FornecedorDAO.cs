using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_PDS.DataBase;
using MySql.Data.MySqlClient;

namespace Projeto_PDS.Models
{
    public class FornecedorDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Fornecedor fornecedor)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "INSERT Into Fornecedor Value " +

                    "(@id, @nome_fantasia, @razao_social, @cnpj, @email, @endereco,  @telefone,)";



                comando.Parameters.AddWithValue("@id", fornecedor.Id);
                comando.Parameters.AddWithValue("@nome_fantasia", fornecedor.Nome);
                comando.Parameters.AddWithValue("@razao_social", fornecedor.Razao );
                comando.Parameters.AddWithValue("@cnpj", fornecedor.Cnpj);
                comando.Parameters.AddWithValue("@email", fornecedor.Email);
                comando.Parameters.AddWithValue("@endereco", fornecedor.Endereco);

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
        public List<Despesa> List(List<Despesa> list)
        {
            try
            {
                List<Fornecedor> List = new List<Fornecedor>();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM fornecedor";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    var Fornecedor = new Fornecedor();
                    Fornecedor.Id = reader.GetInt32("id_for");

                    Fornecedor.Nome = Helpers.DAOHelper.GetString(reader, "nome_fantasia");
                    Fornecedor.Razao = Helpers.DAOHelper.GetString(reader, "razao.social");
                    Fornecedor.Cnpj = Helpers.DAOHelper.GetString(reader, "cnpj");
                    Fornecedor.Email = Helpers.DAOHelper.GetString(reader, "email");
                    Fornecedor.Endereco = Helpers.DAOHelper.GetString(reader, "endereco");
                    Fornecedor.Telefone = Helpers.DAOHelper.GetString(reader, "telefone");
               
                    List.Add(Fornecedor);
                }
                reader.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Fornecedor fornecedor)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "DELETE FROM fornecedor WHERE id_for = @id";
                comando.Parameters.AddWithValue("@id", fornecedor.Id);
                var resultado = comando.ExecuteNonQuery();
                if (resultado == 0)
                {
                    throw new Exception("Ocorreram problemas o salvar as informações");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update(Fornecedor fornecedor)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "UPDATE fornecedor SET " +


                    "id_for = @id," +
                    "nome_fantasia_for = @nome_fantasia," +
                    "razao_social_for = razao_social," +
                    " cnpj_for = @cnpj, " +
                    "email_for = @email," +
                    "endereco_for = @endereco," +
                    "telefone_for = @telefone";


                comando.Parameters.AddWithValue("@id", fornecedor.Id);
                comando.Parameters.AddWithValue("@nome_fantasia", fornecedor.Nome);
                comando.Parameters.AddWithValue("@razao_social", fornecedor.Razao);
                comando.Parameters.AddWithValue("@cnpj", fornecedor.Cnpj);
                comando.Parameters.AddWithValue("@email", fornecedor.Email);
                comando.Parameters.AddWithValue("@endereco", fornecedor.Endereco);
                comando.Parameters.AddWithValue("@telefone", fornecedor.Telefone);

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
