using helloWEBaPI.NewFolder3;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace helloWEBaPI.Controllers
{
    [ApiController]
    [Route("home")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMessage()
        {
            var result= new ResponModel()
            {
                HttpStatus= 200,
                Message = "BEN SEVDİĞİMİ ÇOK ÖZLEDİM."
            };
            return Ok (result);

        }
    }
}
