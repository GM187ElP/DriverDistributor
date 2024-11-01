using System.Data.OleDb;

namespace DriverDistributor.Api.Controllers;

public class QueryExecutor
{
    public Func<string, Func<OleDbDataReader, object>, List<object>> executeQuery = (query, map) =>
    {
        var result = new List<object>();

        using (var connection = new OleDbConnection(""))
        {
            connection.Open();
            using (var command = new OleDbCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(map(reader));
                }
            }
        }
        return result;
    };
}

public class Some()
{
    
}