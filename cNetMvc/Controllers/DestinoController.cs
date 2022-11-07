
using Microsoft.AspNetCore.Mvc;

namespace cNetMvc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DestinoController : ControllerBase
    {
        [HttpGet]

        public string Hello(){
            return "Hello";
        }
    }
}