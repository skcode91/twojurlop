using Microsoft.AspNetCore.Mvc;

namespace TwojUrlop.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GeneralController : Controller
{
    [HttpGet("test")]
    public string a ()
    {
        return "aaaa";
    }
}