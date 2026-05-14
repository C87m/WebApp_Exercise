using Microsoft.AspNetCore.Mvc;
/// <summary>
/// 演習-03 ルーティング属性を利用するコントローラを実装する
/// </summary>
[Route("Exercise03")]  // ルーティング、/Exercise03で実行可能
public class Ex03Controller : Controller
{
    [HttpGet("Morning")]  // /Morningを取得、HttpGetは省略可能
    public IActionResult Goodmorning(){
        return Content("おはようございます。");
    }

    [HttpGet("Evening")]  // /Eveningを取得
    public IActionResult Goodevening(){
        return Content("こんばんは。");
    }
}