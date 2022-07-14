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
            return new ContentResult()
            {
                Content ="<script>" + @"fetch('https://localhost:7109/api/Account/Login', { method:""POST"", credentials: 'include', headers:{ 'Content-Type': 'application/json', 'Accept': 'application/json', 'Access-Control-Allow-Origin' : 'https://coachingg.herokuapp.com', }, body: '{""userName"":""TestingOne"", ""password"":""aA1@3000""}' } ).then(x=>x.json().then(y=>console.log(y)))"+
                "</script>",
                ContentType = "text/html"
            };
        }
    }
}

