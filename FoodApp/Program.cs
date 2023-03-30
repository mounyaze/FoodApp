
using FoodApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Loader;
using Microsoft.AspNetCore.Hosting;

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

MigrateDatabase(app);

void MigrateDatabase(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<FoodAppContext>();
        db.Database.Migrate();
    }
}




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Use(SayHelloMiddlewre);

Task  SayHelloMiddlewre(HttpContext arg1, RequestDelegate arg2)
    
{
    
    if (arg1.Request.Path.StartsWithSegments("/hello")) 
    { 
        return arg1.Response.WriteAsync("Hello, it's Mounya coming at you !");
    }
    else
    {
        return arg2(arg1);
    }
   
}


app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();




app.UseRouting();

app.UseAuthorization();
app.MapControllers();

app.MapRazorPages();

app.Run();
