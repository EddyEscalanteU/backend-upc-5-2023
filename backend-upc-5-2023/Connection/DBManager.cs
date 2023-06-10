using Dapper;
using System.Data.SqlClient;

namespace backend_upc_5_2023.Connection
{
    /// <summary>
    /// Patron de diseño Singleton
    /// </summary>
    public class DBManager
    {
        #region Fields
        private static readonly object lockObj = new();
        private static DBManager? instance;
        #endregion Fields

        #region Constructors
        private DBManager() { }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static DBManager Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new DBManager();
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>
        /// The connection string.
        /// </value>
        public string? ConnectionString { get; set; }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The SQL.</param>
        /// <returns></returns>
        /// <exception cref="SqlException"></exception>
        public IEnumerable<T> GetData<T>(string sql)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            DefaultTypeMap.MatchNamesWithUnderscores = true;
            return connection.Query<T>(sql);
        }

        public IEnumerable<T> GetDataConParametros<T>(string sql, DynamicParameters dynamicParameters)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            DefaultTypeMap.MatchNamesWithUnderscores = true;
            return connection.Query<T>(sql, dynamicParameters);
        }

        /// <summary>
        /// Sets the data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The SQL.</param>
        /// <param name="dynamicParameters">The dynamic parameters.</param>
        /// <returns></returns>
        /// <exception cref="SqlException"></exception>
        public int SetData(string sql, DynamicParameters dynamicParameters)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            DefaultTypeMap.MatchNamesWithUnderscores = true;//SnakeCase to CamelCase
            return connection.Execute(sql, dynamicParameters);
        }

        #endregion Methods
    }
}
