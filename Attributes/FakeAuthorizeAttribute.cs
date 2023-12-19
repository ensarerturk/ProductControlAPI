using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NewProductManagement.Models;
using NewProductManagement.Services;

namespace NewProductManagement.Attributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
public class FakeAuthorizeAttribute : Attribute, IAuthorizationFilter
{
    
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // Get the token from Swagger
        var jwtToken = context.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        string token = TokenManager.GetToken();
        

        // Token verification processes
        if (!jwtToken.Equals(token))
        {
            context.Result = new ForbidResult();
        }
    }
}
