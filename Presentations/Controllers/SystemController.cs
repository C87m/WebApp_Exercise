using Microsoft.AspNetCore.Mvc;
namespace WebApp_Exercise.Presentations.Controllers;
/// <summary>
/// システム停止中画面用コントローラ
/// </summary>
public class SystemController : Controller
{
    [HttpGet]
    public IActionResult Maintenance()
    {
        return View();
    }  
}