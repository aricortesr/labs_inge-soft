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

        public bool CreateCountry(CountryModel country)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = @"INSERT INTO [dbo].[Country]
                  ([Name],[Language],[Continent])
                  VALUES(@Name, @Language, @Continent)";

            var affectedRows = connection.Execute(query, new
            {
                Name = country.Name,
                Language = country.Language,
                Continent = country.Continent
            });

            return affectedRows >= 1;
        }

        public bool DeleteCountry(int id)
        {
            int rowsAffected = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Country WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0;
        }
    }
}