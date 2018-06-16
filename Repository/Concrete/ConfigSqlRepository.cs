using Dapper;
using Repository.Entities;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Repository.Concrete
{
    public class ConfigSqlRepository : IConfigRepository
    {
        readonly string _databaseConnection;
        IDbConnection db;
        Config config = null;

        public ConfigSqlRepository()
        {
            _databaseConnection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        public IReadOnlyList<Config> GetAll()
        {
            IReadOnlyList<Config> configs;

            const string sqlQuery = "SELECT [Key], [Value] FROM Config";
            using (db = new SqlConnection(_databaseConnection)) {
                configs = db.Query<Config>(sqlQuery).ToList();
            }

            return configs;
        }

        public Config GetById(int id)
        {
            const string sqlQuery = "SELECT [Key], [Value] FROM Config WHERE Id = @Id";
            using (db = new SqlConnection(_databaseConnection)) {
                config = db.Query<Config>(sqlQuery, new { Id = id }).FirstOrDefault();
            }

            return config;
        }
        

        public Config GetByKey(string key)
        {
            const string sqlQuery = "SELECT [Key], [Value] FROM Config WHERE [Key] = @key";
            using (db = new SqlConnection(_databaseConnection)) {
                config = db.Query<Config>(sqlQuery, new { Id = key }).FirstOrDefault();
            }

            return config;
        }
    }
}
