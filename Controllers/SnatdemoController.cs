using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SnatExhaustionDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SnatExhaustionDemoController : ControllerBase
    {
        private readonly ILogger<SnatExhaustionDemoController> _logger;
        private readonly IAzureFunctionService _azureFunctionService;
        private readonly IConfiguration _configuration;

        public SnatExhaustionDemoController(ILogger<SnatExhaustionDemoController> logger,
        IAzureFunctionService azureFunctionService,
        IConfiguration config)
        {
            _logger = logger;
            _azureFunctionService = azureFunctionService;
            _configuration = config;
        }

        [HttpGet("/external")]
        public async Task<IActionResult> CallingExternalAsync(){
            await _azureFunctionService.GetAzureFunctionResponse();
            return Ok();
        }
        
        [HttpGet("/externalWrong")]
        public async Task<IActionResult> CallingExternalWrongAsync(){
            HttpClient newClient = new HttpClient();
            newClient.BaseAddress = new System.Uri(_configuration["AzureFunctionOptions:BaseUrl"]);
            newClient.DefaultRequestHeaders.Add("x-functions-key",_configuration["AzureFunctionOptions:xfunctionskey"]);

            await newClient.GetStringAsync("");
            return Ok();
        }
    }
}