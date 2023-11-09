using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TrabajoPractico1.Filters
{
    public class TokenFilters : IAsyncActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            return;
        }

    
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //No logo hacer que el filtro ande.

            /*var httpContext = context.HttpContext;
            var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;

            if (actionDescriptor?.ControllerName == "Login" && actionDescriptor?.ActionName == "Index")
            {
                await next();
                return;
            }

            var token = httpContext.Session.GetString("token");
            if (string.IsNullOrEmpty(token))
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Login", action = "Index" })
                );

            }*/
        }
    }
}
