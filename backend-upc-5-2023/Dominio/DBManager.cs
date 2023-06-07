using System.Data;
using System.Data.SqlClient;

namespace backend_upc_5_2023.Dominio
{
    public class DBManager
    {
        private static object lockObj = new object();
        private static DBManager instance;
        private DBManager() { }
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
        //Other methods removed for brevity


        public string ConnectionString
        {
            get; set;
        }


        public List<Categoria> ExecuteReader(string commandText)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection pgSqlConnection = new
            SqlConnection(ConnectionString))
            using (SqlCommand pgSqlCommand = new SqlCommand())
            {
                pgSqlCommand.CommandText = commandText;
                pgSqlCommand.Connection = pgSqlConnection;
                if (pgSqlConnection.State != ConnectionState.Open)
                    pgSqlConnection.Open();
                SqlDataAdapter pgSqlDataAdapter = new
                   SqlDataAdapter(pgSqlCommand);

                pgSqlDataAdapter.Fill(dataTable);

                var ListofUtilizator = dataTable.AsEnumerable().Select(r =>
                new Categoria
                {
                    Id = r.Field<int>("ID"),
                    Nombre = r.Field<string>("NOMBRE")
                }).ToList();

                return ListofUtilizator;
            }
        }
    }
}
