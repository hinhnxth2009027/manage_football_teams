using MySql.Data.MySqlClient;

namespace FootballManager.helper
{
    public class ConnectionHelper
    {
        private const string Server = "127.0.0.1";
        private const string DbName = "football_league_manager";
        private const string UserName = "root";
        private const string Password = "";
        
        private static readonly string StringConnection =
            $"Server={Server};database={DbName};UID={UserName};password={Password}";
        
        private static MySqlConnection _connection = null;
        
        public static MySqlConnection GetConnection()
        {
            if (_connection == null )
            {
                _connection= new MySqlConnection(StringConnection);
                _connection.Open();
                return _connection;
            }
            else
            {
                return _connection;    
            }
        }
    }
}