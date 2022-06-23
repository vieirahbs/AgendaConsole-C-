using System.Data;
using System.Data.SqlClient;
using AgendaConsole.Helper;

namespace AgendaConsole.Entities
{
    class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public Usuario()
        {
        }

        public static bool CriarCadastro(string nome, string login, string senha)
        {
            bool retorno = false;
            using (SqlConnection conexao = new SqlConnection())
            {
                conexao.ConnectionString = "Data Source=DESKTOP-QINDOBS;Initial Catalog=AGENDA_CONSOLE; Integrated Security=True;Connect Timeout=30";
                conexao.Open();
                using(SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = "insert into USUARIO values (@nome, @login, @senha)";
                    comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = nome;
                    comando.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
                    comando.Parameters.Add("@senha", SqlDbType.VarChar).Value = CriptoHelper.HashMD5(senha);

                    retorno = ((int)comando.ExecuteNonQuery() > 0);
                }
            }
            return retorno;
        }
        
        public static Usuario ValidarUsuario(string login, string senha)
        {
            Usuario retorno = new Usuario();
            using (SqlConnection conexao = new SqlConnection())
            {
                conexao.ConnectionString = "Data Source= DESKTOP-QINDOBS; Initial Catalog=AGENDA_CONSOLE; Integrated Security=True; Connect Timeout=30";
                conexao.Open();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = "select * from USUARIO where LOGIN_US = @login and SENHA_US = @senha";
                    comando.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
                    comando.Parameters.Add("@senha", SqlDbType.VarChar).Value = CriptoHelper.HashMD5(senha);

                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        retorno = new Usuario
                        {
                            Id = (int)reader["ID_US"],
                            Nome = (string)reader["NOME_US"],
                            Login = (string)reader["LOGIN_US"],
                            Senha = (string)reader["SENHA_US"]
                        };
                    }
                }
            }
            return retorno;
        }

        public static Usuario AtualizarNome(int id, string nome)
        {
            Usuario retorno = new Usuario();
            using (SqlConnection conexao = new SqlConnection())
            {
                conexao.ConnectionString = "Data Source=DESKTOP-QINDOBS;Initial Catalog=AGENDA_CONSOLE;Integrated Security=True;Connect Timeout=30";
                conexao.Open();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = "update USUARIO set NOME_US = @nome where ID_US = @id; " +
                    "select * from USUARIO where ID_US = @id";
                    comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = nome;
                    comando.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        retorno = new Usuario
                        {
                            Id = (int)reader["ID_US"],
                            Nome = (string)reader["NOME_US"],
                            Login = (string)reader["LOGIN_US"],
                            Senha = (string)reader["SENHA_US"]
                        };
                    }

                }
            }
            return retorno;
        }

        public static bool AlterarSenha(int id, string senha)
        {
            bool retorno = false;
            using (SqlConnection conexao = new SqlConnection())
            {
                conexao.ConnectionString = "Data Source=DESKTOP-QINDOBS;Initial Catalog=AGENDA_CONSOLE;Integrated Security=True;Connect Timeout=30";
                conexao.Open();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = "update USUARIO set SENHA_US = @senha where ID_US = @id";
                    comando.Parameters.Add("@senha", SqlDbType.VarChar).Value = CriptoHelper.HashMD5(senha);
                    comando.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    retorno = ((int)comando.ExecuteNonQuery() > 0);
                }
            }
            return retorno;
        }

        public static bool ExcluirConta(int id)
        {
            bool retorno = false;
            using (SqlConnection conexao = new SqlConnection())
            {
                conexao.ConnectionString = "Data Source=DESKTOP-QINDOBS;Initial Catalog=AGENDA_CONSOLE;Integrated Security=True;Connect Timeout=30";
                conexao.Open();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = "delete from CONTATO where ID_US = @id; delete from USUARIO where ID_US = @id";
                    comando.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    retorno = ((int)comando.ExecuteNonQuery() > 0);
                }
            }
            return retorno;
        }
    }
}
