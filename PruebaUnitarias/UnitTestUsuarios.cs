using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using backend_upc_5_2023.Servicios;

namespace PruebaUnitarias
{
    [TestCaseOrderer("TestOrderExamples.TestCaseOrdering.AlphabeticalOrderer", "TestOrderExamples")]
    public class UnitTestUsuarios
    {
        public UnitTestUsuarios()
        {
            //utilizar otra BD (temporal)
            DBManager.Instance.ConnectionString = "workstation id=upc-database.mssql.somee.com;packet size=4096;user id=escalante_77_SQLLogin_4;pwd=l6yh7t1jfv;data source=upc-database.mssql.somee.com;persist security info=False;initial catalog=upc-database";
        }

        [Fact]
        public void Usuarios_1_Get_VerificarNotNull()
        {
            var result = UsuariosServicios.Get<Usuarios>();//un listado
            Assert.NotNull(result);
        }

        [Fact]
        public void Usuarios_2_GetById_RegresaItem()
        {
            var result = UsuariosServicios.GetById<Usuarios>(1);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void Usuarios_3_Insertar_RetornaUno()
        {
            Usuarios usuarios = new();
            usuarios.NombreCompleto = "NombreCompleto UnitTest";
            usuarios.UserName = "UserName UnitTest";
            usuarios.Password = "Password UnitTest";

            var result = UsuariosServicios.Insert(usuarios);

            Assert.Equal(1, result);
        }
    }
}
