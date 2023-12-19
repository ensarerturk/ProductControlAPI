using Microsoft.AspNetCore.Mvc;
using NewProductManagement.Attributes;
using NewProductManagement.Models;
using NewProductManagement.Services;

namespace NewProductManagement.Controllers;

[ApiController]
[Route("api/v1/sample-authentications")]
public class SampleController : ControllerBase
{
    private readonly AuthenticationService _authenticationService;

    public SampleController(AuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpGet]
    [FakeAuthorize]
    public IActionResult GetSecureData()
    {
        return Ok("Only logged-in users can access this secure data.");
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] FakeUser request)
    {
        var token = _authenticationService.GenerateJwtToken(request.Username, request.Password);
        
        if (token != null)
        {
            return Ok(new { Token = token });
        }

        return Unauthorized();
    }
}