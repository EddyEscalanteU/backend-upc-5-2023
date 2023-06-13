using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using backend_upc_5_2023.Servicios;

namespace PruebaUnitarias
{
    public class UnitTestCategoria
    {
        public UnitTestCategoria()
        {
            //utilizar otra BD (temporal)
            DBManager.Instance.ConnectionString = "workstation id=upc-database.mssql.somee.com;packet size=4096;user id=escalante_77_SQLLogin_4;pwd=l6yh7t1jfv;data source=upc-database.mssql.somee.com;persist security info=False;initial catalog=upc-database";
        }

        [Fact]
        public void Categoria_Get_VerificarNotNull()
        {
            var result = CategoriaServicios.Get<Categoria>();//un listado
            Assert.NotNull(result);
        }

        [Fact]
        public void Categoria_GetById_RegresaItem()
        {
            var result = CategoriaServicios.GetById<Categoria>(1);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void Categoria_Insertar_RetornaUno()
        {
            Categoria categoria = new();
            categoria.Nombre = "Categoria UnitTest";

            var result = CategoriaServicios.Insert(categoria);

            Assert.Equal(1, result);
        }

        [Fact]
        public void Categoria_Update_RetornaUno()
        {
            Categoria categoria = new();
            categoria.Id = 9;
            categoria.Nombre = "Update UnitTest";

            var result = CategoriaServicios.Update(categoria);

            Assert.Equal(1, result);
        }

        [Fact]
        public void Categoria_Delete_RetornaUno()
        {
            var result = CategoriaServicios.Delete(10);

            Assert.Equal(1, result);
        }
    }
}