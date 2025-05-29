using Blazored.Toast;
using Microsoft.EntityFrameworkCore;
using RegistroTecnico.Components;
using RegistroTecnico.DAL;
using RegistroTecnico.Services;

var builder = WebApplication.CreateBuilder(args);

// Obtener la cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("SqlConStr");

// Registrar el DbContext principal
builder.Services.AddDbContextFactory<ContextoPrueba>(options => 
options.UseSqlServer(connectionString));


// Registrar servicios
builder.Services.AddScoped<TecnicosService>();
builder.Services.AddScoped<ClientesService>();
builder.Services.AddScoped<TicketsService>();

builder.Services.AddBlazoredToast();


// Configuración de Razor Components (Blazor Server)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


var app = builder.Build();

// Middleware de errores y seguridad
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
