using backend_upc_5_2023.Dominio;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace backend_upc_5_2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        readonly IConfiguration _configuration;
        readonly string connectionString;
        public CategoriaController(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString =
            _configuration["SqlConnectionString:DefaultConnection"];
        }

        [HttpGet]
        public IActionResult Get()
        {
            var sql = "select * from CATEGORIA";
            var listCategoria = new List<Categoria>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                listCategoria = connection.Query<Categoria>(sql).ToList();
            }
            return StatusCode(200, listCategoria);
        }
    }
}
