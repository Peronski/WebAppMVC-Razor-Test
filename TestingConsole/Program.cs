// See https://aka.ms/new-console-template for more information
using Test_Cinema.Retrievers;
using Test_Cinema.Persisters;
using Test_Cinema.Models;
using Test_Cinema.Utility;
using Test_Cinema.Controllers;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

SqlConnection connection = new SqlConnection("data source=Pc2031;database=Cinemas;Integrated Security=true;connection timeout=3600");
FilmRetriever filmRetriever = new FilmRetriever(connection);
FilmPersister filmPersister = new FilmPersister(connection, filmRetriever);
FilmController filmController = new FilmController(filmRetriever, filmPersister, null);

SafeOperator.SafeOperation(() => filmRetriever.GetAll(), connection, out IEnumerable<Film> items);

//IEnumerable<Film> items = filmRetriever.GetAll();

foreach(Film film in items)
{
    Console.WriteLine(film.Titolo);
}
