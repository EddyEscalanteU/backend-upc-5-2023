// Ignore Spelling: Categoria

using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using backend_upc_5_2023.Servicios;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace backend_upc_5_2023.Controllers
{
    /// <summary>
    /// Servicios web para la entidad: <see cref="Categoria"/>
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [EnableCors("DevelopmentCors")]
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
                var result = CategoriaServicios.Get<Categoria>();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Gets the categoria by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCategoriaById")]
        public IActionResult GetCategoriaById([FromQuery] int id)
        {
            try
            {
                var result = CategoriaServicios.GetById<Categoria>(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
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
                var result = CategoriaServicios.Insert(categoria);
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
                var result = CategoriaServicios.Update(categoria);
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
                var result = CategoriaServicios.Delete(id);
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
