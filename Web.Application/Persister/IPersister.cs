using Test_Cinema.Retrievers;
using System.Data.SqlClient;

namespace Test_Cinema.Persisters {
    public interface IPersister<T> {
        public SqlConnection Connection { get; set; }
        public IRetriever<T> Retriever { get; set; }
        public bool Add(T item);
        public bool Update(T item, int id);
        public bool Delete(int id);
    }
}
