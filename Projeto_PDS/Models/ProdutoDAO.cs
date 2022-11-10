using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Projeto_PDS.DataBase;

namespace Projeto_PDS.Models
{
    public class ProdutoDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Produto produto)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "CALL InserirProduto" +
                    "(@nome, @valorCompra, @valorVenda, @estoque, @descricao, null)";

                comando.Parameters.AddWithValue("@nome", produto.Nome);
                comando.Parameters.AddWithValue("@valorCompra", produto.ValorCompra);
                comando.Parameters.AddWithValue("@valorVenda", produto.ValorVenda);
                comando.Parameters.AddWithValue("@estoque", produto.Estoque);
                comando.Parameters.AddWithValue("@descricao", produto.Descricao);
                comando.Parameters.AddWithValue("@foto", null);

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

        public List<Produto> List(string busca)
        {
            try
            {
                List<Produto> list = new List<Produto>();

                var query = _conn.Query();
                query.CommandText = "CALL ListarProduto(@busca)";
                query.Parameters.AddWithValue("@busca", busca);

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    var produto = new Produto();
                    produto.Id = reader.GetInt32("id_pro");
                    produto.Nome = Helpers.DAOHelper.GetString(reader, "nome_pro");
                    produto.ValorCompra = Helpers.DAOHelper.GetDouble(reader, "valor_compra_pro");
                    produto.ValorVenda = Helpers.DAOHelper.GetDouble(reader, "valor_venda_pro");
                    produto.Estoque = reader.GetInt32("estoque_pro");
                    produto.Descricao = Helpers.DAOHelper.GetString(reader, "descricao_pro");
                    produto.Foto = Helpers.DAOHelper.GetString(reader, "foto_pro");

                    list.Add(produto);
                }
                reader.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Produto produto)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "CALL DeletarProduto(@id)";
                comando.Parameters.AddWithValue("@id", produto.Id);
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
        public void Update(Produto produto)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "CALL AtualizarProduto" +
                    "(@id, @nome, @valorCompra, @valorVenda, @estoque, @descricao, @foto)";

                comando.Parameters.AddWithValue("@id", produto.Id);
                comando.Parameters.AddWithValue("@nome", produto.Nome);
                comando.Parameters.AddWithValue("@valorCompra", produto.ValorCompra);
                comando.Parameters.AddWithValue("@valorVenda", produto.ValorVenda);
                comando.Parameters.AddWithValue("@estoque", produto.Estoque);
                comando.Parameters.AddWithValue("@descricao", produto.Descricao);
                comando.Parameters.AddWithValue("@foto", null);

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
