using InertiaCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using PingCRM.Data;
using PingCRM.Models;

namespace PingCRM.Middleware;

public class HandleInertiaRequests
{
    private readonly RequestDelegate _next;

    public HandleInertiaRequests(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Inertia.Share("flash", () =>
        {
            var factory = context.RequestServices.GetRequiredService<ITempDataDictionaryFactory>();
            var tempData = factory.GetTempData(context);
            var flash = new Dictionary<string, object>();
            if (tempData.TryGetValue("error", out var error) && error is not null)
            {
                flash.Add("error", error);
            }
            if (tempData.TryGetValue("success", out var success) && success is not null)
            {
                flash.Add("success", success);
            }
            return flash;
        });

        Inertia.Share("auth", () =>
        {
            if (context.User.Identity?.IsAuthenticated == true)
            {
                var userManager = context.RequestServices.GetRequiredService<UserManager<User>>();
                var dbContext = context.RequestServices.GetRequiredService<ApplicationDbContext>();
                var user = userManager.GetUserAsync(context.User).Result;
                if (user != null)
                {
                    // Load the account data separately
                    var account = dbContext.Accounts.Find(user.AccountId);

                    return (object)new
                    {
                        user = new
                        {
                            id = user.Id,
                            first_name = user.FirstName,
                            last_name = user.LastName,
                            email = user.Email,
                            owner = user.Owner,
                            account = new
                            {
                                id = user.AccountId,
                                name = account?.Name
                            }
                        }
                    };
                }
            }
            return (object)new { user = (object?)null };
        });

        await _next(context);
    }
}
