var builder = WebApplication.CreateBuilder(args);

// Добавление сервисов MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Настройка конвейера обработчиков запросов (HTTP request pipeline)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Настройка порта для локального запуска и платформы Render
var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
app.Run($"http://0.0.0.0:{port}");