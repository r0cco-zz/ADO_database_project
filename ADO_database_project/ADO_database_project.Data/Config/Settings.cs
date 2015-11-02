using System.Configuration;

namespace ADO_database_project.Data.Config
{
    public static class Settings
    {
        private static string _connectionString;

        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
                }

                return _connectionString;
            }
        }
    }
}
