using TrabajoPractico1.Filters;


using Rotativa.AspNetCore;
using VentasNet.Infra.Repository.Interfaz;
using VentasNet.Entity.Models;
using VentasNet.Infra.Repository;
using VentasNet.Entity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    //options.Filters.Add<TokenFilters>();
});

builder.Services.AddDbContext<VentasNetContext>(options => options.UseSqlServer(
	builder.Configuration.GetConnectionString("DefaultConnection")));

//Aplico patrong Singleton para que se utilice la misma instancia única del repositorio en toda la aplicación
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IProveedorRepository, ProveedorRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IVentaRepository, VentaRepository>();
builder.Services.AddScoped<IFormaDePagoRepository, FormaDePagoRepository>();
builder.Services.AddScoped<IAuth<Usuario>, UsuarioRepository>();


builder.Services.AddMvc().AddSessionStateTempDataProvider();
builder.Services.AddSession();

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
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
