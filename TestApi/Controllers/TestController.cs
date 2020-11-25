using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Omnium.Nswag.Client;

namespace TestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IBusinessCustomersClient _businessCustomersClient;

        public TestController(IBusinessCustomersClient businessCustomersClient)
        {
            _businessCustomersClient = businessCustomersClient;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _businessCustomersClient.SalesLimitationsGetAsync());
        }
    }
}