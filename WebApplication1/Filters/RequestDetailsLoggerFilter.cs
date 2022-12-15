using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication1.Filters;

public class RequestDetailsLoggerFilter : IActionFilter
{
    private readonly ILogger<RequestDetailsLoggerFilter> _logger;

    public RequestDetailsLoggerFilter(ILogger<RequestDetailsLoggerFilter> logger)
    {
        _logger = logger;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ActionDescriptor is not ControllerActionDescriptor actionDescriptor)
        {
            return;
        }

        _logger.LogDebug(
            $"Action '{actionDescriptor.ActionName}' from controller '{actionDescriptor.ControllerName}' has been executed at {DateTime.Now:s}");
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}
