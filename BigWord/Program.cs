using BigWord.BL.Services;
using BigWord.Data.Context;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<WordsDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IValidWordService, ValidWordService>();

WebApplication app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Submission}/{action=Submit}/{id?}")
    .WithStaticAssets();


app.Run();