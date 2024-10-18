using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApiTemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DBController : ControllerBase
    {
        [HttpGet, Route("/init")]
        public async Task<ActionResult<string>> InitSampleDB()
        {
            Factory.DB.Init.InitDB.Init();
            return "Done";
        }
    }
}
