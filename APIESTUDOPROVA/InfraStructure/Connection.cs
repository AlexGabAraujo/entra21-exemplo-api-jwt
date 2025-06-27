using APIESTUDOPROVA.Contracts.InfraStructure;
using Dapper;
using MySql.Data.MySqlClient;

namespace APIESTUDOPROVA.InfraStructure
{
    public class Connection : IConnection
    {
        protected string connectionString = "Server=localhost;Database=cu;User=root;Password=root;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public async Task<int> Execute(string sql, object obj)
        {
            using (MySqlConnection con = GetConnection())
            {
                return await con.ExecuteAsync(sql, obj);
            }
        }
    }
}
