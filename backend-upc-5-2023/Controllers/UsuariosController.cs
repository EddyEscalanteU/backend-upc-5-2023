using backend_upc_5_2023.Dominio;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace backend_upc_5_2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        readonly IConfiguration _configuration;
        readonly string connectionString;
        public UsuariosController(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString =
            _configuration["SqlConnectionString:DefaultConnection"];
        }

        [HttpGet]
        public IActionResult Get()
        {
            var sql = "select * from Usuarios";
            var listUsuarios = new List<Usuarios>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                listUsuarios = connection.Query<Usuarios>(sql).ToList();
            }
            return StatusCode(200, listUsuarios);
        }
    }
}
