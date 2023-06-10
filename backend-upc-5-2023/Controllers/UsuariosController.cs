using backend_upc_5_2023.Connection;
using backend_upc_5_2023.Dominio;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace backend_upc_5_2023.Controllers
{
    /// <summary>
    /// Servicios web para la entidad: <see cref="Usuarios"/>
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        #region Fields
        private readonly IConfiguration _configuration;
        private readonly string? connectionString;
        #endregion Fields

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="UsuariosController"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public UsuariosController(IConfiguration configuration)
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
                const string sql = "select * from USUARIOS  WHERE ESTADO_REGISTRO = 1";

                var result = DBManager.Instance.GetData<Usuarios>(sql);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetUsuarioById")]
        public IActionResult GetUsuarioById(int Id)
        {
            try
            {
                const string sql = "SELECT * FROM USUARIOS WHERE ID = @Id AND ESTADO_REGISTRO = 1";

                var parameters = new DynamicParameters();
                parameters.Add("ID", Id, DbType.Int64);

                var result = DBManager.Instance.GetDataConParametros<Usuarios>(sql, parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddUsuario")]
        public IActionResult Insert(Usuarios usuarios)
        {
            try
            {
                const string sql = "INSERT INTO [dbo].[USUARIOS]([USER_NAME], [NOMBRE_COMPLETO], [PASSWORD]) VALUES (@UserName, @NombreCompleto, @Password) ";

                var parameters = new DynamicParameters();
                parameters.Add("UserName", usuarios.UserName, DbType.String);
                parameters.Add("NombreCompleto", usuarios.NombreCompleto, DbType.String);
                parameters.Add("Password", usuarios.Password, DbType.String);

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
