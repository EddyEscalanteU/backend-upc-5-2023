using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace backend_upc_5_2023.Controllers
{
    /// <summary>
    /// Servicios web para la entidad: <see cref="HProducto"/>
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class HProductoController : ControllerBase
    {
        #region Fields
        private readonly IConfiguration _configuration;
        private readonly string? connectionString;
        #endregion Fields

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="HProductoController"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public HProductoController(IConfiguration configuration)
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
                const string sql = "select * from H_PRODUCTO  WHERE ESTADO_REGISTRO = 1";

                var result = DBManager.Instance.GetData<HProducto>(sql);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        #endregion Methods
    }
}
