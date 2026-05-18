using Microsoft.AspNetCore.Mvc;
/// <summary>
/// 演習-07 フォームデータを取得するコントローラを実装する
/// </summary>
[Route("Option03")]
public class Op03Controller : Controller
{
    /// <summary>
    /// 入力値を加算した結果を返す
    /// </summary>
    /// <param name="form">入力値を保持するViewModel</param>
    /// <returns></returns>
    [HttpPost("Calc")]
    public IActionResult Calc(Op03Form form)  // ViewModelのExercise07formクラスから受け取る、インスタンス生成・値代入済み
    {
        if(form.Opt == 1)
        {
            var result = form.Value1 + form.Value2;
            return Content($"{form.Value1} + {form.Value2} = {result}");   
        }
        else if(form.Opt == 2)
        {
            var result = form.Value1 - form.Value2;
            return Content($"{form.Value1} - {form.Value2} = {result}"); 
        }
        else if(form.Opt == 3)
        {
            var result = form.Value1 * form.Value2;
            return Content($"{form.Value1} * {form.Value2} = {result}"); 
        }
        else if(form.Opt == 0)
        {
            return Content("ゼロ除算エラー");
        }
        else if(form.Opt == 4)
        {
            var result = (double)form.Value1 / form.Value2;
            return Content($"{form.Value1} / {form.Value2} = {result}"); 
        }
        else if(form.Opt == 5)
        {
            var result = form.Value1 % form.Value2;
            return Content($"{form.Value1} % {form.Value2} = {result}");
        }
        else
        {
            return Content("不明な計算種別です");
        }
    }
}