using backend_lab.Models;
using Dapper;
using System.Data.SqlClient;

namespace backend_lab.Repositories
{
    public class CountryRepository
    {
        private readonly string _connectionString;

        public CountryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<CountryModel> GetCountries()
        {
            using var connection = new SqlConnection(_connectionString);
            string query = "SELECT * FROM dbo.Country";
            return connection.Query<CountryModel>(query).ToList();
        }
    }
}