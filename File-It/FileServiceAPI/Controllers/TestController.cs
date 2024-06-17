using FileServiceAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileServiceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "holy shit het werkt";
        }
    }
}
