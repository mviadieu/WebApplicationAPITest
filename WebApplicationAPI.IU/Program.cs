using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.IU.ExtentionsMethods;
using WebApplicationAPI.IU.Middlewares;
using WebApplicationAPICore.Recipies.Domain;
using WebApplicationAPICore.Recipies.Infrastructure.Datas;
using WebApplicationAPICore.Recipies.Infrastructure.Loggers;
using WebApplicationAPICore.Recipies.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RecipiesContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("master")));

builder.Services.AddDefaultIdentity<IdentityUser>(option =>
{
    option.Password.RequireDigit = true;
    option.Password.RequireUppercase = true; // CONFIGURER LES REGLES PSWD ETC. REGARDER LES OPTIONS
}).AddEntityFrameworkStores<RecipiesContext>();

builder.Services.AddInjection();
builder.Services.AddCustomSecurity(builder.Configuration);
builder.Logging.AddProvider(new CustomLoggerProvider());

var app = builder.Build();
app.UseMiddleware<LogRequestMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Recette")) // (IsDevelopment, IsProduction, IsStagging de base. On peut en rajouter manuellement)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();  

app.UseRouting(); 

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseCors(SecurityMethods.DEFAULT_POLICY);
app.Run();