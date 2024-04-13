using System.Net.Http;

namespace DungeonsAndNotes;

public class Connection
{
    private static Connection? _connection;
    public readonly HttpClient Client;
        
    private Connection()
    {
        Client = new HttpClient();
    }

    public static Connection GetConnection()
    {
        if (_connection == null)
        {
            _connection = new Connection();
        }

        return _connection;
    }
}
