using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace backend_upc_5_2023.Controllers
{
    /// <summary>
    /// Servicios web para la entidad: <see cref="Producto"/>
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        #region Fields
        private readonly IConfiguration _configuration;
        private readonly string? connectionString;
        #endregion Fields

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductoController"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public ProductoController(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString =
            _configuration["SqlConnectionString:DefaultConnection"];
            DBManager.Instance.ConnectionString = connectionString;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="SqlException"></exception>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                const string sql = "SELECT * FROM PRODUCTO WHERE ESTADO_REGISTRO = 1";

                var result = DBManager.Instance.GetData<Producto>(sql);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetProductoById")]
        public IActionResult GetProductoById(int Id)
        {
            try
            {
                string sql = "SELECT * FROM PRODUCTO WHERE ID = @Id AND ESTADO_REGISTRO = 1";

                var parameters = new DynamicParameters();
                parameters.Add("ID", Id, DbType.Int64);

                var result = DBManager.Instance.GetDataConParametros<Producto>(sql, parameters);

                Producto producto = result.FirstOrDefault();

                //////////////////////////////

                if (producto != null)
                {
                    sql = "SELECT * FROM CATEGORIA WHERE ID = @Id AND ESTADO_REGISTRO = 1";

                    var parameters2 = new DynamicParameters();
                    parameters2.Add("ID", producto.IdCategoria, DbType.Int64);

                    var result2 = DBManager.Instance.GetDataConParametros<Categoria>(sql, parameters2);

                    producto.Categoria = result2.FirstOrDefault();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddProducto")]
        public IActionResult Insert(Producto producto)
        {
            try
            {
                const string sql = "INSERT INTO [dbo].[PRODUCTO]([NOMBRE], [ID_CATEGORIA]) VALUES (@Nombre, @IdCategoria) ";
                var parameters = new DynamicParameters();
                parameters.Add("Nombre", producto.Nombre, DbType.String);
                parameters.Add("IdCategoria", producto.IdCategoria, DbType.Int64);

                var result = DBManager.Instance.SetData(sql, parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("UpdateProducto")]
        public IActionResult Update(Producto producto)
        {
            try
            {
                const string sql = "UPDATE [dbo].[PRODUCTO] SET NOMBRE = @Nombre, ID_CATEGORIA = @IdCategoria WHERE ID = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("ID", producto.Id, DbType.Int64);
                parameters.Add("NOMBRE", producto.Nombre, DbType.String);
                parameters.Add("IdCategoria", producto.IdCategoria, DbType.Int64);

                var result = DBManager.Instance.SetData(sql, parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("DeleteProducto")]
        public IActionResult Delete(int id)
        {
            try
            {
                const string sql = "UPDATE [dbo].[PRODUCTO] SET ESTADO_REGISTRO = 0 WHERE ID = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("ID", id, DbType.Int64);

                var result = DBManager.Instance.SetData(sql, parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion Methods
    }
}
