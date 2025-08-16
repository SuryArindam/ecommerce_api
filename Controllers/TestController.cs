using ecommerce_api.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using IAppConfig = ecommerce_api.Config.IAppConfig;

namespace ecommerce_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IAppConfig _appConfig;
        public TestController(IAppConfig appConfig)
        {
            _appConfig = appConfig;
           
        }
        [HttpGet]
        public string Padmanav()
        {
            var _tester = new DbConnectionTester(_appConfig);
            _tester.IsConnectionSuccessful(out string message);
            return message;
        }
    }
}
