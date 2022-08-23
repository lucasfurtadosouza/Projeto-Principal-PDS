using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_PDS.DataBase;


namespace Projeto_PDS.Models
{
    public class DespesaDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Despesa despesa)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "INSERT Into Despesa Value " +

                    "(@id, @valor, @data_vencimento, @data_pagamento, @forma_pagamento,  @descricao,)";



                comando.Parameters.AddWithValue("@id", despesa.Valor);
                comando.Parameters.AddWithValue("@valor", despesa.Valor);
                comando.Parameters.AddWithValue("@data_vencimento", despesa.Data_Vencimento);
                comando.Parameters.AddWithValue("@data_pagamento", despesa.Data_Pagamento);
                comando.Parameters.AddWithValue("@forma_pagamento", despesa.Forma_Pagamento);
                comando.Parameters.AddWithValue("@descricao", despesa.Descrição);


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
        public void Delete(Despesa despesa)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "DELETE FROM despesa WHERE id_esc = @id";
                comando.Parameters.AddWithValue("@id", despesa.id);
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
        public void Update(Despesa despesa)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "UPDATE Despesa SET " +


                    "id_des = @id," +
                    "valor_desc = @valor," +
                    " data_vencimento_des = @Data_Vencimento," +
                    " data_pagamento = @Data_Pagamento, " +
                    "forma_pagamento_des = @Forma_Pagamento," +
                    "descricao = @Descriçao " ;

                comando.Parameters.AddWithValue("@id", despesa.id);
                comando.Parameters.AddWithValue("@fantasia", despesa.Valor);
                comando.Parameters.AddWithValue("@razao", despesa.Data_Vencimento);
                comando.Parameters.AddWithValue("@cnpj", despesa.Data_Pagamento);
                comando.Parameters.AddWithValue("@cnpj", despesa.Forma_Pagamento);
                comando.Parameters.AddWithValue("@insc", despesa.Descrição);
 
           


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
