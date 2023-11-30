using app_card.Factory;
using app_card.Models;
using app_card.Models.Interfaces;
using app_card.Repositories;
using Vereyon.Web;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddFlashMessage();
builder.Services.AddSession(options =>
{
    options.IdleTimeout=TimeSpan.FromMinutes(10);
});
var configurationRoot = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();
//{

//    builder.Configuration["Appsettings:ConnectionStrings:BIRTHDAYCARDS"] = "";

//    "Server=localhost;Database=ChristmasCards;Integrated Security=true;"
//Server = localhost; Database = BirthdayCards; Integrated Security = true; ",
//}
//builder.Configuration["Appsettings:connectionString"] = "";

builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<IRepositoryFactory, RepositoryFactory>();
builder.Services.AddControllersWithViews()
    .AddViewOptions(options =>
    {
        options.HtmlHelperOptions.ClientValidationEnabled=true;
    });
var entorno = builder.Environment.EnvironmentName;




var conexion = builder.Configuration.GetConnectionString(DataSource.BIRTHDAYCARDS.ToString());

WebApplication app = builder.Build();
var en = app.Environment.IsStaging();


// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//}
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}");

app.Run();
