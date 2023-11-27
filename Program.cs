// Importaciones necesarias para el funcionamiento del programa
using HotelManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using HotelManager;

// Crear una instancia del constructor de la aplicación web
var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor de dependencias.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HotelManager")));

// Configurar la identidad por defecto con ApplicationUser y agregar almacén de entidades al contexto de la base de datos
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()  // Agrega roles a la configuración
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<SignInManager<ApplicationUser>, SignInManager<ApplicationUser>>();

// Construir la aplicación
var app = builder.Build();

// Sembrar roles
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    SeedRoles(roleManager);
}

static void SeedRoles(RoleManager<IdentityRole> roleManager)
{
    string[] roleNames = { "Admin", "Empleado", "Cliente" };

    foreach (var roleName in roleNames)
    {
        if (!roleManager.RoleExistsAsync(roleName).Result)
        {
            IdentityRole role = new IdentityRole();
            role.Name = roleName;

            IdentityResult roleResult = roleManager.
            CreateAsync(role).Result;
        }
    }
}


// Configurar el canal de solicitud HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // El valor predeterminado de HSTS es de 30 días. Puede que desees cambiar esto para escenarios de producción, consulta https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Mapear las páginas Razor
app.MapRazorPages();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

// Mapear la ruta del controlador predeterminado
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Ejecutar la aplicación
app.Run();
