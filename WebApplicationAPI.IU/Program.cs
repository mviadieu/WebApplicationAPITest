using Microsoft.EntityFrameworkCore;
using WebApplicationAPICore.Recipies.Domain;
using WebApplicationAPICore.Recipies.Infrastructure.Datas;
using WebApplicationAPICore.Recipies.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RecipiesContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("master")));

builder.Services.AddTransient<IRecipiesRepository, DefaultRecipieRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseCors(builder =>
    {
        builder
            .WithOrigins("http://localhost:4200", "https://localhost:4200")
            .SetIsOriginAllowedToAllowWildcardSubdomains()
            .AllowAnyHeader()
            .AllowCredentials()
            .WithMethods("GET", "PUT", "POST", "DELETE", "OPTIONS")
            .SetPreflightMaxAge(TimeSpan.FromSeconds(3600));
 
    }
);

app.Run();