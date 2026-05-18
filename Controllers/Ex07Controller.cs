using Microsoft.AspNetCore.Mvc;
/// <summary>
/// 演習-07 フォームデータを取得するコントローラを実装する
/// </summary>
[Route("Exercise07")]
public class Ex07Controller : Controller
{
    /// <summary>
    /// 入力値を加算した結果を返す
    /// </summary>
    /// <param name="form">入力値を保持するViewModel</param>
    /// <returns></returns>
    [HttpPost("Calc")]
    public IActionResult Calc(Exercise07Form form)  // ViewModelのExercise07formクラスから受け取る、インスタンス生成・値代入済み
    {
        var result = form.Value1 + form.Value2;
        return Content($"{form.Value1} + {form.Value2} = {result}");
    }
}