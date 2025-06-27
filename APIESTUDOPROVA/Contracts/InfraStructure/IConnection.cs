using MySql.Data.MySqlClient;

namespace APIESTUDOPROVA.Contracts.InfraStructure
{
    public interface IConnection
    {
        MySqlConnection GetConnection();

        Task<int> Execute(string sql, object obj);
    }
}
