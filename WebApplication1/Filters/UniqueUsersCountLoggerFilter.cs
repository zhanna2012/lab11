using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication1.Models;

namespace WebApplication1.Filters;

public class UniqueUsersCountLoggerFilter : Attribute, IActionFilter
{
    private readonly List<string> _authorizedUsers = new();

    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ActionArguments.First().Value is not UserLogin userLogin)
        {
            return;
        }

        var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<UniqueUsersCountLoggerFilter>>();

        if (!_authorizedUsers.Contains(userLogin.Login))
        {
            _authorizedUsers.Add(userLogin.Login);
            logger.LogDebug($"Adding new unique user with login '{userLogin.Login}'");
            return;
        }

        logger.LogDebug($"User with login '{userLogin.Login}' is already authorized");
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}
