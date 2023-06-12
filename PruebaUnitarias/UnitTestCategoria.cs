using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using backend_upc_5_2023.Servicios;

namespace PruebaUnitarias
{
    public class UnitTestCategoria
    {
        public UnitTestCategoria()
        {
            DBManager.Instance.ConnectionString = "workstation id=upc-database.mssql.somee.com;packet size=4096;user id=escalante_77_SQLLogin_4;pwd=l6yh7t1jfv;data source=upc-database.mssql.somee.com;persist security info=False;initial catalog=upc-database";
        }
        [Fact]
        public void Verificar_GetCategoria_RegresaListado()
        {
            var result = CategoriaServicios.Get<Categoria>();
            Assert.NotNull(result);
        }

        [Fact]
        public void Verificar_GetByIdCategoria_RegresaItem()
        {
            var result = CategoriaServicios.GetById<Categoria>(1);
            Assert.NotNull(result);
        }
    }
}