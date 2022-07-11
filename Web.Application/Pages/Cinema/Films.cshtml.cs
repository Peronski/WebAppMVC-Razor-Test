using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test_Cinema.Models;
using Test_Cinema.Persisters;
using Test_Cinema.Retrievers;
using Test_Cinema.Utility;

namespace Web.Application.Pages.Films
{
    public class FilmsModel : PageModel
    {
        public FilmsModel(IRetriever<Film> retriever, IPersister<Film> persister)
        {
            Retriever = retriever;
            Persister = persister;
        }

        public IRetriever<Film> Retriever { get; private set; }
        public IPersister<Film> Persister { get; private set; }

        public List<Film> FilmList { get; private set; }

        public void OnGet()
        {
            //FilmList = new List<Film>();
            SafeOperator.SafeOperationIEnumerable(() => Retriever.GetAll(), Retriever.Connection, out IEnumerable<Film> items);
            FilmList = items.ToList();
        }
    }
}
