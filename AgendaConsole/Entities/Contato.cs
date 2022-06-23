using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AgendaConsole.Entities
{
    class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public Contato()
        {
        }

        public Contato(string nome, string telefone)
        {
            Nome = nome;
            Telefone = telefone;
        }
        
        public static List<Contato> RecuperaListaContato(int idUsuario)
        {
            List<Contato> retorno = new List<Contato>();
            using (SqlConnection conexao = new SqlConnection())
            {
                conexao.ConnectionString = "Data Source=DESKTOP-QINDOBS;Initial Catalog=AGENDA_CONSOLE;Integrated Security=True; Connect Timeout=30";
                conexao.Open();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = "select * from CONTATO inner join USUARIO " +
                        "on CONTATO.ID_US = USUARIO.ID_US where USUARIO.ID_US = @idUsuario order by NOME";
                    comando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
                        
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        retorno.Add( new Contato { 
                        Id = (int)reader["ID"],
                        Nome = (string)reader["NOME"],
                        Telefone = (string)reader["TELEFONE"]                        
                        });
                    }
                }
            }
            return retorno;
        }

        public static Contato RecuperaContato(int id)
        {
            Contato retorno = new Contato();
            using (SqlConnection conexao = new SqlConnection())
            {
                conexao.ConnectionString = "Data Source=DESKTOP-QINDOBS;Initial Catalog=AGENDA_CONSOLE;Integrated Security=True; Connect Timeout=30";
                conexao.Open();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = "select * from CONTATO where ID = @id";
                    comando.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        retorno = new Contato
                        {
                            Id = (int)reader["ID"],
                            Nome = (string)reader["NOME"],
                            Telefone = (string)reader["TELEFONE"]
                        };
                    }
                }
            }
            return retorno;
        }

        public static bool AdicionarContato(int idUsuario, string nome, string telefone)
        {
            bool retorno = false;
            using(SqlConnection conexao = new SqlConnection())
            {
                conexao.ConnectionString = "Data Source=DESKTOP-QINDOBS;Initial Catalog=AGENDA_CONSOLE;Integrated Security=True;Connect Timeout=30";
                conexao.Open();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = "insert into CONTATO values (@idUsuario, @nome, @telefone)";
                    comando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
                    comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = nome;
                    comando.Parameters.Add("@telefone", SqlDbType.VarChar).Value = telefone;

                    retorno = ((int)comando.ExecuteNonQuery() > 0);
                }
            }
            return retorno;
        }

        public static bool EditarContato(int id, string nome, string telefone)
        {
            bool retorno = false;
            using (SqlConnection conexao = new SqlConnection())
            {
                conexao.ConnectionString = "Data Source=DESKTOP-QINDOBS; Initial Catalog=AGENDA_CONSOLE; Integrated Security=True;Connect Timeout=30";
                conexao.Open();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = "update CONTATO set NOME = @nome, TELEFONE = @telefone " +
                        "where ID = @id";
                    comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = nome;
                    comando.Parameters.Add("@telefone", SqlDbType.VarChar).Value = telefone;
                    comando.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    retorno = ((int)comando.ExecuteNonQuery() > 0);
                }
            }
            return retorno;
        }

        public static bool DeletarContato(int id)
        {
            bool retorno = false;
            Contato contato = RecuperaContato(id);
            if (contato.Nome != null)
            {
                using (SqlConnection conexao = new SqlConnection())
                {
                    conexao.ConnectionString = "Data Source=DESKTOP-QINDOBS;Initial Catalog=AGENDA_CONSOLE;Integrated Security=True;Connect Timeout=30";
                    conexao.Open();
                    using(SqlCommand comando = new SqlCommand())
                    {
                        comando.Connection = conexao;
                        comando.CommandText = "delete from CONTATO where ID = @id";
                        comando.Parameters.Add("@id", SqlDbType.Int).Value = id;

                        retorno = ((int)comando.ExecuteNonQuery() > 0);
                    }
                }
            }
            return retorno;
        }
    }
}
