using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoachingApp.Controllers
{
    [Route("")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        [HttpGet]
        public ContentResult Index()
        {
            string html = System.IO.File.ReadAllText(@"./wwwroot/index.html");
            return base.Content(html, "text/html");
        }
    }
}

