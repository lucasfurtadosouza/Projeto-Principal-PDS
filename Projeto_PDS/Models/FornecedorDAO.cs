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

                comando.CommandText = "CALL InserirFornecedor" +
                    "(@nomeFantasia, @razaoSocial, @cnpj, @email, @rua, @numero, @bairro, @telefone)";

                comando.Parameters.AddWithValue("@nomeFantasia", fornecedor.Nome);
                comando.Parameters.AddWithValue("@razaoSocial", fornecedor.Razao);
                comando.Parameters.AddWithValue("@cnpj", fornecedor.Cnpj);
                comando.Parameters.AddWithValue("@email", fornecedor.Email);
                comando.Parameters.AddWithValue("@rua", fornecedor.Rua);
                comando.Parameters.AddWithValue("@numero", fornecedor.Numero);
                comando.Parameters.AddWithValue("@bairro", fornecedor.Bairro);
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
        public List<Fornecedor> List( string busca)
        {
            try
            {
                List<Fornecedor> list = new List<Fornecedor>();

                var query = _conn.Query();
                query.CommandText = "CALL ListarFornecedor(@busca)";
                query.Parameters.AddWithValue("@busca", busca);

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    var Fornecedor = new Fornecedor();
                    Fornecedor.Id = reader.GetInt32("id_for");

                    Fornecedor.Nome = Helpers.DAOHelper.GetString(reader, "nome_fantasia_for");
                    Fornecedor.Razao = Helpers.DAOHelper.GetString(reader, "razao_social_for");
                    Fornecedor.Cnpj = Helpers.DAOHelper.GetString(reader, "cnpj_for");
                    Fornecedor.Email = Helpers.DAOHelper.GetString(reader, "email_for");
                    Fornecedor.Rua = Helpers.DAOHelper.GetString(reader, "rua_for");
                    Fornecedor.Numero = Convert.ToInt32(Helpers.DAOHelper.GetString(reader, "numero_for"));
                    Fornecedor.Bairro = Helpers.DAOHelper.GetString(reader, "bairro_for");
                    Fornecedor.Telefone = Helpers.DAOHelper.GetString(reader, "telefone_for");
               
                    list.Add(Fornecedor);
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
                comando.CommandText = "CALL DeletarFornecedor(@id)";
                comando.Parameters.AddWithValue("@id", fornecedor.Id);
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
        public void Update(Fornecedor fornecedor)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "CALL AtualizarFornecedor" +
                    "(@id, @nomeFantasia, @razaoSocial, @cnpj, @email, @rua, @numero, @bairro, @telefone)";

                comando.Parameters.AddWithValue("@id", fornecedor.Id);
                comando.Parameters.AddWithValue("@nomeFantasia", fornecedor.Nome);
                comando.Parameters.AddWithValue("@razaoSocial", fornecedor.Razao);
                comando.Parameters.AddWithValue("@cnpj", fornecedor.Cnpj);
                comando.Parameters.AddWithValue("@email", fornecedor.Email);
                comando.Parameters.AddWithValue("@rua", fornecedor.Rua);
                comando.Parameters.AddWithValue("@numero", fornecedor.Numero);
                comando.Parameters.AddWithValue("@bairro", fornecedor.Bairro);
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
