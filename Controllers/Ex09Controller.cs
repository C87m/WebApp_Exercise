using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
/// <summary>
/// 演習-09 HTML Formを作成するタグヘルパーを利用する
/// </summary>
[Route("Exercise09")]
public class Ex09Controller : Controller
{
    /// <summary>
    /// 入力画面を表示する
    /// </summary>
    /// <returns></returns>
    [HttpGet("Enter")]
    public ActionResult Enter()
    {
        var form = new Exercise07Form();
        return View(form);
    }

    /// <summary>
    /// 計算処理と結果画面表示アクション
    /// </summary>
    /// <returns></returns>
    [HttpGet("Result")]
    public IActionResult Result()
    {
        // TempDataからExercise07Formを取り出す
        string? json = (string ) TempData["Exercise07Form"]!;
        if (string.IsNullOrEmpty(json))
        {
            // TempDataにExercise07Formが無い場合、入力画面表示にリダイレクトする
            return RedirectToAction("Enter");
        }
        // 存在する場合はデシリアライズする
        var form = JsonSerializer.Deserialize<Exercise07Form>(json);
        form!.Answer = form.Value1 + form.Value2;
        return View(form);
    }

    /// <summary>
    /// [戻る]ボタンクリックアクション
    /// </summary>
    /// <returns></returns>
    [HttpGet("Back")]
    public IActionResult Back()
    {
        // var form = new Exercise07Form();
        // return View("Enter", form);
        return RedirectToAction("Enter");
    }

    /// <summary>
    /// [計算]ボタンクリックアクション
    /// </summary>
    /// <returns></returns>
    [HttpPost("Calc")]
    public IActionResult Calc(Exercise07Form form)
    {
        // バリデーションチェック
        if (!ModelState.IsValid)
        {
            // バリデーションエラーの場合入力画面を表示する
            return View("Enter", form);
        }
        // Exercise07Formをシリアライズする
        var json = JsonSerializer.Serialize(form);
        // TempDataに登録する
        TempData["Exercise07Form"] = json;
        // 計算結果を表示するResultへリダイレクトする
        return RedirectToAction("Result");
    }
}