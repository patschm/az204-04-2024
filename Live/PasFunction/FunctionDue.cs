using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace PasFunction;

public class FunctionDue
{
    private readonly ILogger _logger;

    public FunctionDue(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<FunctionDue>();
    }

    [Function("FunctionDue")]
    public void Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer)
    {
        _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        
        if (myTimer.ScheduleStatus is not null)
        {
            _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
        }
    }
}
