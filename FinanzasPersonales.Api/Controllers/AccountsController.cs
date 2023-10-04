using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanzasPersonales.Api.Controllers;

[ApiController]
[Route("accounts")]
[Authorize]
public class AccountsController : ControllerBase
{
    [HttpGet("list")]
    public IActionResult ListAccounts()
    {
        return Ok(Array.Empty<string>());
    }
}