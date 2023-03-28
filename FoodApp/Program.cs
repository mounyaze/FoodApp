
using FoodApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Loader;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorPages();



builder.Services.AddDbContext<FoodAppContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("FoodAppCore"));
});

builder.Services.AddScoped<IRestaurantData, SqlRestaurantData>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
