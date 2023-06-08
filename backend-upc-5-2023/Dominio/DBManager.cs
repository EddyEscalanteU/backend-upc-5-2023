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

    }
}
