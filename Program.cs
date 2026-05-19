using WebApp_Exercise.Presentations.Extensions;
using WebApp_Exercise_Answer.Presentations.Middlewares;

var builder = WebApplication.CreateBuilder(args);  //WebApplicationBuilderの作成

// Add services to the container.
builder.Services.AddControllersWithViews();  
builder.Services.SettingDependencyInjection(builder.Configuration);      // DIコンテナにMVCコントローラとビューを追加

var app = builder.Build(); 

app.UseMiddleware<InternalExceptionLoggingMiddleware>();                        // WebApplicationを構築

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())              // HTTPリクエストパイプラインの構成
{
    app.UseExceptionHandler("/Home/Error");        // 開発環境でない場合にエラー
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();  // httpsへのリダイレクト
app.UseStaticFiles();       // 静的ファイルの利用

app.UseRouting();           // ルーティングの有効化

app.UseAuthorization();     // 認可を有効化

app.MapControllerRoute(     // ルートパターンの設定
    name: "default",        // ルートの名前
    pattern: "{controller=Home}/{action=Index}/{id?}"); // URLパターン、何もしない場合Home/Indexを開く

app.Run();                  // アプリケーションの起動
