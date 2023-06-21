using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using Dapper;
using System.Data;

namespace backend_upc_5_2023.Servicios
{
    /// <summary>
    /// Clase de servicios para la entidad: <see cref="Producto"/>
    /// </summary>
    public static class ProductoServicios
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static IEnumerable<Producto> Get()
        {
            const string sql = "SELECT * FROM PRODUCTO WHERE ESTADO_REGISTRO = 1";

            var enummerableProductos = DBManager.Instance.GetData<Producto>(sql);

            foreach (var item in enummerableProductos)
            {
                item.Categoria = CategoriaServicios.GetById<Categoria>(item.IdCategoria);
            }

            return enummerableProductos;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static Producto GetById(int id)
        {
            const string sql = "SELECT * FROM PRODUCTO WHERE ID = @Id AND ESTADO_REGISTRO = 1";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int64);

            var result = DBManager.Instance.GetDataConParametros<Producto>(sql, parameters);

            Producto producto = result.FirstOrDefault();

            if (producto != null)
            {
                producto.Categoria = CategoriaServicios.GetById<Categoria>(producto.IdCategoria);
            }

            return result.FirstOrDefault();
        }

        /// <summary>
        /// Inserts the specified producto.
        /// </summary>
        /// <param name="producto">The producto.</param>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static int Insert(Producto producto)
        {
            const string sql = "INSERT INTO [PRODUCTO]([NOMBRE], [ID_CATEGORIA]) VALUES (@Nombre, @IdCategoria) ";
            var parameters = new DynamicParameters();
            parameters.Add("Nombre", producto.Nombre, DbType.String);
            parameters.Add("IdCategoria", producto.IdCategoria, DbType.Int64);

            var result = DBManager.Instance.SetData(sql, parameters);

            return result;
        }

        /// <summary>
        /// Updates the specified producto.
        /// </summary>
        /// <param name="producto">The producto.</param>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static int Update(Producto producto)
        {
            const string sql = "UPDATE [PRODUCTO] SET NOMBRE = @Nombre, ID_CATEGORIA = @IdCategoria WHERE ID = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", producto.Id, DbType.Int64);
            parameters.Add("Nombre", producto.Nombre, DbType.String);
            parameters.Add("IdCategoria", producto.IdCategoria, DbType.Int64);

            var result = DBManager.Instance.SetData(sql, parameters);

            return result;
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        public static int Delete(int id)
        {
            const string sql = "UPDATE [PRODUCTO] SET ESTADO_REGISTRO = 0 WHERE ID = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("ID", id, DbType.Int64);

            var result = DBManager.Instance.SetData(sql, parameters);
            return result;
        }
    }
}
