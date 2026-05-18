using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
/// <summary>
/// オプション演習-04 タグヘルパーを利用する
/// 入力データを保持するViewModel
/// </summary>
public class Option04Form
{
    [Display(Name = "値1")]
    [Required(ErrorMessage = "{0}は入力必須です。")]
    [Range(0, 1000 , ErrorMessage = "{0}は{1}～{2}までの数字で入力してください。")]
    public int Value1 { get; set; } = 0;
    [Display(Name = "値2")]
    [Required(ErrorMessage = "{0}は入力必須です。")]
    [Range(0, 1000 , ErrorMessage = "{0}は{1}～{2}までの数字で入力してください。")]
    public int Value2 { get; set; } = 0;

    [Display(Name = "計算の種類")]
    [Range(1, 5, ErrorMessage = "計算の種類が選択されていません。")]
    public int Option { get; set; } 
    /// <summary>
    /// プルダウン表示するリスト
    /// </summary>
    /// <value></value>
    public List<SelectListItem> OptionsList { get; set; } = new List<SelectListItem>
    {
        new SelectListItem{ Text="--選択されていません--", Value="0" , Selected = true },
        new SelectListItem{ Text= "加算", Value= "1" },
        new SelectListItem{ Text= "除算", Value= "2" },
        new SelectListItem{ Text= "乗算", Value= "3" },
        new SelectListItem{ Text= "除算", Value= "4" },
        new SelectListItem{ Text= "剰余", Value= "5" },
    };

    /// <summary>
    /// 演習-09 HTML Formを作成するタグヘルパーを利用する
    /// </summary>

    /// <summary>
    /// 計算結果
    /// </summary>
    /// <value></value>
    public int Answer { get; set; }
}