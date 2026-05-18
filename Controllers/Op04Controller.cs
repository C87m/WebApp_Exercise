using Microsoft.AspNetCore.Mvc;
/// <summary>
/// 演習-04 [FormQuery]属性を利用してクエリパラメータを受け取る
/// </summary>
[Route("Option04")]
public class Op04Controller : Controller
{
    /// <summary>
    /// 入力画面を表示する
    /// </summary>
    /// <returns></returns>
    [HttpGet("Enter")]
    public IActionResult Enter()
    {
        var form = new Option04Form();
        return View(form);
    }
    /// <summary>
    /// リクエストパラメータを加算した結果を返す
    /// </summary>
    /// <param name="value1">加算対象</param>
    /// <param name="value2">加算対象</param>
    /// <returns>加算結果</returns>
    [HttpPost("Result")]
    public IActionResult Result(Option04Form form)
    {
        if (!ModelState.IsValid)
        {
            return View("Enter",form);
        }
        switch(form.Option)
        {
            case 1:
            form.Answer = form.Value1 + form.Value2;  
            return View(form);
        
            case 2:
            form.Answer = form.Value1 - form.Value2;
            return View(form);

            case 3:
            form.Answer = form.Value1 * form.Value2; 
            return View(form);
            
            case 4:
            if(form.Value2 == 0)
                {
                    ModelState.AddModelError("Value", "ゼロ除算エラー");
                    return View(form);
                }
            form.Answer = form.Value1 / form.Value2; 
            return View(form);
        
            case 5:
            if(form.Value2 == 0)
                {
                    ModelState.AddModelError("Value", "ゼロ除算エラー");
                    return View(form);
                }
            form.Answer = form.Value1 % form.Value2;
            return View(form);
        
            default:
            ModelState.AddModelError("Opt", "不明な計算種別です。");
            return View(form);
        }
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
}