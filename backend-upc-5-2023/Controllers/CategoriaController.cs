using backend_upc_5_2023.Dominio;
using Microsoft.AspNetCore.Mvc;

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
        public List<Categoria> Get()
        {
            DBManager.Instance.ConnectionString = connectionString;
            var result = DBManager.Instance.ExecuteReader("select * from CATEGORIA");
            return result;
        }
    }
}
