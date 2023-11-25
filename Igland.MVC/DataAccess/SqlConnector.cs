using Igland.MVC.Entities;
using MySqlConnector;
using System.Data;
using System.Data.Common;

namespace Igland.MVC.DataAccess
{

    /// <summary>
    /// Class SqlConnector with external interface "ISqlConnector" that provides methods to obtain a MySQL/MariaDB database connection based on the configuration.
    /// </summary>
    public class SqlConnector : ISqlConnector
    {
        private readonly IConfiguration config;


        /// <summary>
        /// IConfiguration retrieves configuration settings     
        /// </summary>
        /// <param name="config"> provides external configuration</param>
        public SqlConnector(IConfiguration config)
        {
            this.config = config;
        }


        /// <summary>
        /// Providing a MySqlConnection object as an IDbConnection
        /// </summary>
        /// <returns> a new instance of MySqlConnection, a part of IDbConnection </returns>
        public IDbConnection GetDbConnection()
        {
            return new MySqlConnection(config.GetConnectionString("MariaDb"));
        }
          
    }
}
