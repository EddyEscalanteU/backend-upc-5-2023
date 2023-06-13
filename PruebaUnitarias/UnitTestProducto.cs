using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using backend_upc_5_2023.Servicios;

namespace PruebaUnitarias
{
    public class UnitTestProducto
    {
        public UnitTestProducto()
        {
            //utilizar otra BD (temporal)
            DBManager.Instance.ConnectionString = "workstation id=upc-database.mssql.somee.com;packet size=4096;user id=escalante_77_SQLLogin_4;pwd=l6yh7t1jfv;data source=upc-database.mssql.somee.com;persist security info=False;initial catalog=upc-database";
        }

        [Fact]
        public void Producto_Get_VerificarNotNull()
        {
            var result = ProductoServicios.Get<Producto>();//un listado
            Assert.NotNull(result);
        }

        [Fact]
        public void Producto_GetById_RegresaItem()
        {
            var result = ProductoServicios.GetById(1);
            Assert.Equal(1, result.Id);
        }
    }
}
