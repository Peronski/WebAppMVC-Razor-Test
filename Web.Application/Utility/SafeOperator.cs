using System.Data.SqlClient;

namespace Test_Cinema.Utility{
    public class SafeOperator {
        public static bool SafeOperation<T>(System.Func<T> action, SqlConnection connection, out T? result) {
            try {
                connection.Open();
                result = action();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);

                result = default(T);

                return false;
            }finally {
                connection.Close(); 
            }

            return true;
        }

        public static bool SafeOperationIEnumerable<T>(System.Func<T> action, SqlConnection connection, out T? result)
        {
            try
            {
                connection.Open();
                result = action();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                result = default(T);

                return false;
            }
            //finally
            //{
                //connection.Close(); //connection is closed when trying to materialize IEnumerable 
            //}

            return true;
        }
    }
}
