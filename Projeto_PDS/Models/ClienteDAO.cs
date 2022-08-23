using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Projeto_PDS.DataBase;

namespace Projeto_PDS.Models
{
    public class ClienteDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Cliente cliente)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "INSERT Into Cliente Value " +

                    "(null, @nome, @email, @cpf, @telefone, @endereco, @rg, @data_nasc, @sexo, @renda_familiar, @foto)";

                comando.Parameters.AddWithValue("@nome", cliente.Nome);
                comando.Parameters.AddWithValue("@email", cliente.Email);
                comando.Parameters.AddWithValue("@telefone", cliente.Telefone);
                comando.Parameters.AddWithValue("@endereco", cliente.Endereco);
                comando.Parameters.AddWithValue("@rg", cliente.Rg);
                comando.Parameters.AddWithValue("@data_nasc", cliente.DataNasc?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@sexo", cliente.Sexo);
                comando.Parameters.AddWithValue("@renda_familiar", cliente.RendaFamiliar);
                comando.Parameters.AddWithValue("@foto", cliente.Foto);

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

        public List<Cliente> List()
        {
            try
            {
                List<Cliente> list = new List<Cliente>();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM cliente";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    var cliente = new Cliente();
                    cliente.Id = reader.GetInt32("id_cli");
                    cliente.Email = Helpers.DAOHelper.GetString(reader, "nome_fantasia_esc");
                    escola.RazaoSocial = Helpers.DAOHelper.GetString(reader, "razao_social_esc");
                    escola.Responsavel = Helpers.DAOHelper.GetString(reader, "responsavel_esc");
                    escola.DataCricao = Convert.ToDateTime(Helpers.DAOHelper.GetString(reader, "data_criacao_esc"));
                    escola.Numero = Convert.ToInt32(Helpers.DAOHelper.GetString(reader, "numero_esc"));

                    list.Add(escola);
                }
                reader.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Escola escola)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "DELETE FROM escola WHERE id_esc = @id";
                comando.Parameters.AddWithValue("@id", escola.Id);
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
        public void Update(Escola escola)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "UPDATE Escola SET " +
                    "nome_fantasia_esc = @fantasia, razao_social_esc = @razao, cnpj_esc = @cnpj, insc_estadual_esc = @insc, tipo_esc = @tipo, data_criacao_esc = @data_cricao,responsavel_esc = @resp, responsavel_telefone_esc = @resp_telefone, email_esc = @email," +
                    " telefone_esc = @telefone, rua_esc = @rua, numero_esc = @numero, bairro_esc = @bairro, complemento_esc = @complemento, cep_esc = @cep, cidade_esc = @cidade, estado_esc = @estado " +
                    "WHERE id_esc = @id";


                comando.Parameters.AddWithValue("@fantasia", escola.NomeFantasia);
                comando.Parameters.AddWithValue("@razao", escola.RazaoSocial);
                comando.Parameters.AddWithValue("@cnpj", escola.CNPJ);
                comando.Parameters.AddWithValue("@insc", escola.InscEstadual);
                comando.Parameters.AddWithValue("@tipo", escola.Tipo);
                comando.Parameters.AddWithValue("@data_cricao", escola.DataCricao?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@resp", escola.Responsavel);
                comando.Parameters.AddWithValue("@resp_telefone", escola.TelefoneResp);
                comando.Parameters.AddWithValue("@email", escola.Email);
                comando.Parameters.AddWithValue("@telefone", escola.Telefone);
                comando.Parameters.AddWithValue("@rua", escola.Rua);
                comando.Parameters.AddWithValue("@numero", escola.Numero);
                comando.Parameters.AddWithValue("@bairro", escola.Bairro);
                comando.Parameters.AddWithValue("@complemento", escola.Complemento);
                comando.Parameters.AddWithValue("@cep", escola.CEP);
                comando.Parameters.AddWithValue("@cidade", escola.Cidade);
                comando.Parameters.AddWithValue("@estado", escola.Estado);
                comando.Parameters.AddWithValue("@id", escola.Id);


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
        public List<Escola> List4()
        {
            try
            {
                List<Escola> escola = new List<Escola>();

                var queryCount = _conn.Query();
                queryCount.CommandText = "SELECT COUNT(id_esc) FROM Escola";

                MySqlDataReader reader = queryCount.ExecuteReader();

                while (reader.Read())
                {
                    var cadastroescola = new Escola();
                    cadastroescola.EscolaCount = reader.GetInt32("count(id_esc)");

                    escola.Add(cadastroescola);
                }
                reader.Close();
                return escola;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
