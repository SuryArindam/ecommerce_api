
using ecommerce_api.Config;
using Microsoft.Data.SqlClient;

namespace ecommerce_api
{
    public class DbConnectionTester
    {
        private readonly string _connectionString;
        private IAppConfig _appConfig;
        public DbConnectionTester(IAppConfig appConfig)
        {
            _connectionString = appConfig.GetConnectionString();
        }
        public bool IsConnectionSuccessful(out string message)
        {
            
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    message = "Connection successful";
                    return true;
                }
                catch (Exception ex)
                {
                    message = $"Connection failed={ex.Message}";
                    return false;
                }
            }
        }
    }
}
