using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using backend_upc_5_2023.Servicios;

namespace PruebaUnitarias
{
    [TestCaseOrderer("TestOrderExamples.TestCaseOrdering.PriorityOrderer", "TestOrderExamples")]
    public class UnitTestCategoria
    {
        public UnitTestCategoria()
        {
            //utilizar otra BD (temporal)
            DBManager.Instance.ConnectionString = "workstation id=upc-database.mssql.somee.com;packet size=4096;user id=escalante_77_SQLLogin_4;pwd=l6yh7t1jfv;data source=upc-database.mssql.somee.com;persist security info=False;initial catalog=upc-database";
        }

        [Fact, TestPriority(0)]
        public void Categoria_Get_VerificarNotNull()
        {
            // Arrange
            // Declarar variables
            Console.WriteLine("TestPriority(0)");

            // Act
            // Usar Métodos
            var result = CategoriaServicios.Get<Categoria>();//un listado

            // Assert
            // Las Comparaciones
            Assert.NotNull(result);
        }

        [Fact, TestPriority(1)]
        public void Categoria_GetById_RegresaItem()
        {
            Console.WriteLine("TestPriority(1)");
            var result = CategoriaServicios.GetById<Categoria>(1);
            Assert.Equal(1, result.Id);
        }

        [Fact, TestPriority(2)]
        public void Categoria_Insertar_RetornaUno()
        {
            // Arrange
            Console.WriteLine("TestPriority(2)");
            Categoria categoria = new();
            categoria.Nombre = "Categoria UnitTest";

            // Act
            var result = CategoriaServicios.Insert(categoria);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact, TestPriority(3)]
        public void Categoria_Update_RetornaUno()
        {
            Console.WriteLine("TestPriority(3)");
            Categoria categoria = new();
            categoria.Id = 9;
            categoria.Nombre = "Update UnitTest";

            var result = CategoriaServicios.Update(categoria);

            Assert.Equal(1, result);
        }

        [Fact, TestPriority(4)]
        public void Categoria_Delete_RetornaUno()
        {
            Console.WriteLine("TestPriority(4)");
            var result = CategoriaServicios.Delete(10);

            Assert.Equal(1, result);
        }
    }
}