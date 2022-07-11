using Test_Cinema.Models;
using System.Data.SqlClient;

namespace Test_Cinema.Retrievers {
    public class FilmRetriever : IRetriever<Film> {

        public FilmRetriever(SqlConnection connection) {
            Connection = connection;
        }

        public SqlConnection Connection { get; set; }

        public Film Get(int id) {
            string query = @"SELECT [Titolo],
                                    [Autore],
                                    [Produttore],
                                    [Genere],
                                    [Durata]
                               FROM [Cinemas].[dbo].[Films]
                              WHERE [Id] = @id";

            SqlCommand sqlCommand = new SqlCommand(query, Connection);

            sqlCommand.Parameters.AddWithValue("@id", id);

            //Connection.Open();

            using (SqlDataReader reader = sqlCommand.ExecuteReader()) {
                while (reader.Read()) {
                    return new Film() {
                        Id = id,
                        Titolo = reader["Titolo"].ToString(),
                        Autore = reader["Autore"].ToString(),
                        Produttore = reader["Produttore"].ToString(),
                        Genere = reader["Genere"].ToString(),
                        Durata = TimeSpan.Parse(reader["Durata"].ToString())
                    };
                }
            }

            return null;
        }

        public IEnumerable<Film> GetAll() {
            string query = @"SELECT [Id],
                                    [Titolo],
                                    [Autore],
                                    [Produttore],
                                    [Genere],
                                    [Durata]
                               FROM [Cinemas].[dbo].[Films]";

            SqlCommand sqlCommand = new SqlCommand(query, Connection);

            //Connection.Open();

            using (SqlDataReader reader = sqlCommand.ExecuteReader()) {
                while (reader.Read()) {
                    yield return new Film {
                        Id = int.Parse(reader["Id"].ToString()),
                        Titolo = reader["Titolo"].ToString(),
                        Autore = reader["Autore"].ToString(),
                        Produttore = reader["Produttore"].ToString(),
                        Genere = reader["Genere"].ToString(),
                        Durata = TimeSpan.Parse(reader["Durata"].ToString())
                    };
                }
            }

            //Connection.Close();
        }
    }
}
