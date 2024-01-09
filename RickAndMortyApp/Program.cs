using Microsoft.EntityFrameworkCore;
using RickAndMortyApp.Data.Entities;
using RickAndMortyApp.Models;
using RickAndMortyApp.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<EpisodeService>(client =>
{
    client.BaseAddress = new Uri("https://rickandmortyapi.com/api/");
});

builder.Services.AddHttpClient<CharacterService>(client =>
{
    client.BaseAddress = new Uri("https://rickandmortyapi.com/api/");
});

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });

});


builder.Services.AddTransient<EpisodeService>();

builder.Services.AddTransient<CharacterService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
