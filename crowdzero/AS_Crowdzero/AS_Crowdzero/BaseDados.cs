using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; // Livraria para trabalhar com BD
using System.Data.SqlClient; // Livraria para trabalhar com o SQLServer
using System.Configuration;

namespace AS_Crowdzero
{
    class BaseDados
    {
        string strLigacao;
        SqlConnection LigacaoBD;

        public BaseDados()
        {
            //strLigacao = ConfigurationManager.ConnectionStrings["diserver4.BDbEdi.scdi59"].ToString();
            LigacaoBD = new SqlConnection("Data Source = 193.137.7.32; Persist Security Info=True;User ID = diei59; Password=DI@2020");
            LigacaoBD.Open();
        }
        ~BaseDados()
        {
            try
            {
                LigacaoBD.Close();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.Message);
            }
        }

        // Método executar um script de SQL para Manipular/alterar Dados
        public void executa_SQL(string sql)
        {
            SqlCommand comando = new SqlCommand(); // Classe para executar um comando de SQL
            comando.CommandText = sql;
            comando.Connection = LigacaoBD; // Ligar o comando à Base de dados onde se vai executar o Script de SQL
            comando.ExecuteNonQuery(); // Executar o comando de SQL para alteração de dados.
            comando.Dispose(); // Libertar a variavel
                               // comando = null; -> APAGAR CONTEUDO DA VARIÁVEL
        }

        // Método executar um script de SQL com utilização de parmetros
        public void executa_SQL(string sql, List<SqlParameter> parametros)
        {
            SqlCommand comando = new SqlCommand(sql, LigacaoBD); // Vincular o comando à Base de Dados
            comando.Parameters.AddRange(parametros.ToArray()); // Associar os parametros ao comando
            comando.ExecuteNonQuery(); // Executar o comando
            comando.Dispose();
        }

        // Iniciar a transação
        public SqlTransaction iniciar_transacao()
        {
            return LigacaoBD.BeginTransaction();
        }

        // Método executar um script de SQL com utilização de transação
        public void executa_SQL(string sql, List<SqlParameter> parametros, SqlTransaction transacao)
        {
            SqlCommand comando = new SqlCommand(sql, LigacaoBD); // Vincular o comando à Base de Dados
            comando.Parameters.AddRange(parametros.ToArray()); // Associar os parametros ao comando
            comando.Transaction = transacao;

            if (comando.ExecuteNonQuery() > 0)
            {
                transacao.Commit();
            }
            else
            {
                transacao.Rollback();
            }

            comando.Dispose();
        }

        // Método executar uma consulta de SQL
        public DataTable devolveconsulta(string sql)
        {
            SqlCommand comando = new SqlCommand(sql, LigacaoBD);
            DataTable registos = new DataTable();
            SqlDataReader dados = comando.ExecuteReader();
            registos.Load(dados);
            comando.Dispose();
            return registos;

        }

        public DataTable devolveconsulta(string sql, List<SqlParameter> param)
        {
            SqlCommand comando = new SqlCommand(sql, LigacaoBD);
            comando.Parameters.AddRange(param.ToArray());
            DataTable registos = new DataTable();
            SqlDataReader dados = comando.ExecuteReader();
            registos.Load(dados);
            comando.Dispose();
            return registos;

        }
    }
}
