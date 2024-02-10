using Exception_Interceptor.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace Exception_Interceptor.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("make")]
        //Русский текст
        public IActionResult MakeMessage(string msg)
        {
            if (msg == "ok")
            {
                return Ok(msg);
            }
            else
            {
                throw new ArgumentException("Msg should be equal 'ok'");
            }
        }

        [HttpGet]
        [Route("sql")]
        public void ExecuteSql(string sql)
        {
            using var conn = new NpgsqlConnection("server=localhost:5432;database=postgres;uid=postgres;password=POSTGRES_PASSWORD;");
            conn.Open();

            using var tr = conn.BeginTransaction();

            using var command_locale = new NpgsqlCommand
            {
                Connection = tr.Connection,
                CommandText = "set lc_messages = 'ru_RU.UTF-8';"
            };

            command_locale.ExecuteNonQuery();


            using var command = new NpgsqlCommand
            {
                Connection = tr.Connection,
                CommandText = sql
            };

            command.Parameters.Add(new NpgsqlParameter("v", "value"));

            command.ExecuteNonQuery();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new[] { "a", "b", "c" });
        }


        [HttpGet]
        [Route("show")]
        public void ShowModel([FromQuery] TableExample1 tableExample1)
        {
            Console.WriteLine(tableExample1);
        }
    }
}
