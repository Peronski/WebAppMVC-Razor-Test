using Test_Cinema.Models;
using System.Data.SqlClient;
using Test_Cinema.Retrievers;

namespace Test_Cinema.Persisters {
    public class FilmPersister : IPersister<Film> {

        public SqlConnection Connection { get; set; }
        public IRetriever<Film> Retriever { get; set; }

        public FilmPersister(SqlConnection connection, IRetriever<Film> customerRetriever) {
            Connection = connection;
            Retriever = customerRetriever;
        }


        public bool Add(Film item) {
            string query = @"INSERT INTO [Cinemas].[dbo].[Films] (Titolo, Autore, Produttore, Genere, Durata)
                                 VALUES(@Titolo, @Autore, @Produttore, @Genere, @Durata);";

            SqlCommand sqlCommand = new SqlCommand(query, Connection);

            sqlCommand.Parameters.AddWithValue("@Titolo", item.Titolo);
            sqlCommand.Parameters.AddWithValue("@Autore", item.Autore);
            sqlCommand.Parameters.AddWithValue("@Produttore", item.Produttore);
            sqlCommand.Parameters.AddWithValue("@Genere", item.Genere);
            sqlCommand.Parameters.AddWithValue("@Durata", item.Durata);

            //Connection.Open();

            return Convert.ToInt32(sqlCommand.ExecuteScalar()) > 0;
        }

        public bool Delete(int id) {
            if (Retriever.Get(id) != null) {
                string query = @"DELETE FROM [Cinemas].[dbo].[Films]
                                WHERE [Id] = @id";

                SqlCommand sqlCommand = new SqlCommand(query, Connection);

                sqlCommand.Parameters.AddWithValue("@id", id);

                //Connection.Open();

                return sqlCommand.ExecuteNonQuery() > 0;
            }

            return false;
        }

        public bool Update(Film item, int id) {
            if (Retriever.Get(id) != null) {
                string query = @"UPDATE [Cinemas].[dbo].[Films] (Titolo, Autore, Produttore, Genere, Durata)
                                 SET [Titolo] = @Titolo,
                                     [Autore] = @Autore,
                                     [Produttore] = @Produttore,
                                     [Genere] = @Genere,
                                     [Durata] = @Durata
                                FROM [Cinemas].[dbo].[Films]
                                WHERE [Id] = @id";

                SqlCommand sqlCommand = new SqlCommand(query, Connection);

                sqlCommand.Parameters.AddWithValue("@Titolo", item.Titolo);
                sqlCommand.Parameters.AddWithValue("@Autore", item.Autore);
                sqlCommand.Parameters.AddWithValue("@Produttore", item.Produttore);
                sqlCommand.Parameters.AddWithValue("@Genere", item.Genere);
                sqlCommand.Parameters.AddWithValue("@Durata", item.Durata);

                //Connection.Open();

                return sqlCommand.ExecuteNonQuery() > 0;
            }

            return Add(item);
        }
    }
}
