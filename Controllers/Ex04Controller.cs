using Microsoft.AspNetCore.Mvc;
/// <summary>
/// 演習-04 [FormQuery]属性を利用してクエリパラメータを受け取る
/// </summary>
[Route("Exercise04")]
public class Ex04Controller : Controller
{
    /// <summary>
    /// リクエストパラメータを加算した結果を返す
    /// </summary>
    /// <param name="value1">加算対象</param>
    /// <param name="value2">加算対象</param>
    /// <returns>加算結果</returns>
    [HttpGet("Calc")]
    public IActionResult Calc([FromQuery(Name = "v1")] int value1 ,[FromQuery(Name = "v2")] int value2)  // URIの?以降を受け取る、(Name="")でクエリパラメータ名を変えられる
    {
        // 演習-05 型変換エラーの場合、エラーメッセージを出力する
        /** 追加 **/
        if (! ModelState.IsValid) // クエリパラメータ名で認識されるので注意
        {
            // value1とvalue2で型変換エラー
            if ((ModelState["v1"]?.Errors.Count ?? 0) > 0   
            &&  (ModelState["v2"]?.Errors.Count ?? 0) > 0)
            {
                return Content("value1とvalue2は整数ではありません。");
            }
            // value1で型変換エラー
            if ((ModelState["v1"]?.Errors.Count ?? 0) > 0)
            {
                return Content("value1は整数ではありません。");
            }
            // value2で型変換エラー
            if ((ModelState["v2"]?.Errors.Count ?? 0) > 0)
            {
                return Content("value2は整数ではありません。");
            }
        }
        var result = value1 + value2;
        return Content($"{value1} + {value2} = {result}");
    }
}