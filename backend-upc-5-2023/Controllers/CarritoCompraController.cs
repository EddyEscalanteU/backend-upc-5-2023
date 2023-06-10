// Ignore Spelling: Carrito

using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace backend_upc_5_2023.Controllers
{
    /// <summary>
    /// Servicios web para la entidad: <see cref="CarritoCompra"/>
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoCompraController : ControllerBase
    {
        #region Fields
        private readonly IConfiguration _configuration;
        private readonly string? connectionString;
        #endregion Fields

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="CarritoCompraController"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public CarritoCompraController(IConfiguration configuration)
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
                const string sql = "select * from CARRITO_COMPRA  WHERE ESTADO_REGISTRO = 1";

                var result = DBManager.Instance.GetData<CarritoCompra>(sql);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetCarritoCompraById")]
        public IActionResult GetCarritoCompraById(int Id)
        {
            try
            {
                string sql = "select * from CARRITO_COMPRA WHERE ID = @Id AND ESTADO_REGISTRO = 1";

                var parameters = new DynamicParameters();
                parameters.Add("ID", Id, DbType.Int64);

                var result = DBManager.Instance.GetDataConParametros<CarritoCompra>(sql, parameters);

                CarritoCompra carritoCompra = result.FirstOrDefault();

                //////////////////////////////

                if (carritoCompra != null)
                {
                    sql = "SELECT * FROM H_PRODUCTO WHERE ID_CARRITO_COMPRA = @IdCarritoCompra AND ESTADO_REGISTRO = 1";

                    var parameters2 = new DynamicParameters();
                    parameters2.Add("IdCarritoCompra", carritoCompra.Id, DbType.Int64);

                    var result2 = DBManager.Instance.GetDataConParametros<HProducto>(sql, parameters2);

                    carritoCompra.Productos = result2.ToList();
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
        [Route("AddCarritoCompra")]
        public IActionResult Insert(CarritoCompra carritoCompra)
        {
            try
            {
                const string sql = "INSERT INTO [dbo].[CARRITO_COMPRA]([FECHA], [ID_USUARIO]) VALUES (@Fecha, @IdUsuario) ";
                var parameters = new DynamicParameters();
                parameters.Add("Fecha", DateTime.Now, DbType.DateTime);
                parameters.Add("IdUsuario", carritoCompra.IdUsuario, DbType.Int64);

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
