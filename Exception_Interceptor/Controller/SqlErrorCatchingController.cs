using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace Exception_Interceptor.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class SqlErrorCatchingController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public SqlErrorCatchingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("sql")]
        public void ExecuteSql(string sql)
        {
            using var conn = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            conn.Open();

            using var tr = conn.BeginTransaction();

            ///
            using var command_locale = new NpgsqlCommand
            {
                Connection = tr.Connection,
                CommandText = "set lc_messages = 'ru_RU.UTF-8';"
            };

            command_locale.ExecuteNonQuery();
            ///

            using var command = new NpgsqlCommand
            {
                Connection = tr.Connection,
                CommandText = sql
            };

            command.Parameters.Add(new NpgsqlParameter("v", "value"));

            command.ExecuteNonQuery();
        }
    }
}
