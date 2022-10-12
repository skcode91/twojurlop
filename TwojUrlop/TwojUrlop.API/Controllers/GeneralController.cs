using Microsoft.AspNetCore.Mvc;

namespace TwojUrlop.Controllers;

public class GeneralController : Controller
{
    [HttpGet]
    public string a ()
    {
        return "aaaa";
    }
}