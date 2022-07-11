using System.Data.SqlClient;

namespace Test_Cinema.Retrievers {
    public interface IRetriever<T> {
        public SqlConnection Connection { get; set; }
        public T Get(int id);
        public IEnumerable<T> GetAll();
    }
}
