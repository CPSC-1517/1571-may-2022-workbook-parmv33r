using Microsoft.EntityFrameworkCore;
using WestWindSystem;

var builder = WebApplication.CreateBuilder(args);

//Add Services to the web application container
//this registeration will use the WWBackEndDependencies() method
//coded in the library
//1) retrieve the connections string information from your appsettings.json
var connectionString = builder.Configuration.GetConnectionString("WWDB");

//2) setup the registeration of services to be used in your web application
builder.Services.WWBackendDependencies(options => options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

