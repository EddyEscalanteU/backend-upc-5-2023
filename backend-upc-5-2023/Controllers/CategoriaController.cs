// Ignore Spelling: Categoria

using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace backend_upc_5_2023.Controllers
{
    /// <summary>
    /// Servicios web para la entidad: <see cref="Categoria"/>
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        #region Fields
        private readonly IConfiguration _configuration;
        private readonly string? connectionString;
        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoriaController"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public CategoriaController(IConfiguration configuration)
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
        /// <exception cref="System.Data.SqlClient.SqlException"></exception>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                const string sql = "SELECT * FROM CATEGORIA WHERE ESTADO_REGISTRO = 1";

                var result = DBManager.Instance.GetData<Categoria>(sql);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetCategoriaById")]
        public IActionResult GetCategoriaById(int Id)
        {
            try
            {
                const string sql = "SELECT * FROM CATEGORIA WHERE ID = @Id AND ESTADO_REGISTRO = 1";

                var parameters = new DynamicParameters();
                parameters.Add("ID", Id, DbType.Int64);

                var result = DBManager.Instance.GetDataConParametros<Categoria>(sql, parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Adds the specified categoria.
        /// </summary>
        /// <param name="categoria">The categoria.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddCategoria")]
        public IActionResult Insert(Categoria categoria)
        {
            try
            {
                const string sql = "INSERT INTO [dbo].[CATEGORIA]([NOMBRE]) VALUES (@Nombre) ";
                var parameters = new DynamicParameters();
                parameters.Add("Nombre", categoria.Nombre, DbType.String);

                var result = DBManager.Instance.SetData(sql, parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Updates the specified categoria.
        /// </summary>
        /// <param name="categoria">The categoria.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateCategoria")]
        public IActionResult Update(Categoria categoria)
        {
            try
            {
                const string sql = "UPDATE [dbo].[CATEGORIA] SET NOMBRE = @Nombre WHERE ID = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("ID", categoria.Id, DbType.Int64);
                parameters.Add("NOMBRE", categoria.Nombre, DbType.String);

                var result = DBManager.Instance.SetData(sql, parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteCategoria")]
        public IActionResult Delete(int id)
        {
            try
            {
                const string sql = "UPDATE [dbo].[CATEGORIA] SET ESTADO_REGISTRO = 0 WHERE ID = @Id";
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
