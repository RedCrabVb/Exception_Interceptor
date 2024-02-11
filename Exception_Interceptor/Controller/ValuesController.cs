using Exception_Interceptor.Logic.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Exception_Interceptor.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        [HttpGet]
        [Route("make")]
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
        public IActionResult Get()
        {
            return Ok(new[] { "a", "b", "c" });
        }


        [HttpGet]
        [Route("show")]
        public void ShowModel([FromQuery] TableExample1Dto tableExample1)
        {
            Console.WriteLine(tableExample1);
        }
    }
}
