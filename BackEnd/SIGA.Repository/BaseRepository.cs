using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SIGA.Repository
{
    public abstract class BaseRepository
    {
        public static IConfiguration _config;
        public IDbConnection ConnectionSql
        {
            get => new SqlConnection(_config.GetConnectionString("Storage"));
        }
    }
}
