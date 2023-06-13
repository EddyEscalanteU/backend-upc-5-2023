using backend_upc_5_2023.Connection;

namespace PruebaUnitarias
{
    public class UnitTestUsuarios
    {
        public UnitTestUsuarios()
        {
            //utilizar otra BD (temporal)
            DBManager.Instance.ConnectionString = "workstation id=upc-database.mssql.somee.com;packet size=4096;user id=escalante_77_SQLLogin_4;pwd=l6yh7t1jfv;data source=upc-database.mssql.somee.com;persist security info=False;initial catalog=upc-database";
        }

        [Fact]
        public void Usuarios_Get_VerificarNotNull()
        {

        }
    }
}
