using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace PasFunction;

public class MyFun
{
    private readonly ILogger<MyFun> _logger;

    public MyFun(ILogger<MyFun> logger)
    {
        _logger = logger;
    }

    [Function("FunctionUno")]
    public IActionResult Loop(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route ="me/{blaat}")] HttpRequest req, string blaat)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        _logger.LogInformation($"Het zegt: {blaat}");
        return new OkObjectResult("Welcome to Azure Functions!");
    }
}
