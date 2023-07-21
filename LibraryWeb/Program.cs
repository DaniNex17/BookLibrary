using Infraestructure.Context;
using LibraryWeb.Handlers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


#region Context SQL Server
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStringSQLServer"));

});
#endregion


#region Inyection
DependencyInyectionHandler.DependencyInyectionConfig(builder.Services);
#endregion


// Add services to the container.
builder.Services.AddControllersWithViews();

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

// Rutas adicionales para AuthorController
app.MapControllerRoute(
    name: "author",
    pattern: "Author/{action}/{id?}",
    defaults: new { controller = "Author" });

// Rutas adicionales para EditorialController
app.MapControllerRoute(
    name: "editorial",
    pattern: "Editorial/{action}/{id?}",
    defaults: new { controller = "Editorial" });

// Rutas adicionales para BookController
app.MapControllerRoute(
    name: "book",
    pattern: "Book/{action}/{id?}",
    defaults: new { controller = "Book" });


app.Run();
