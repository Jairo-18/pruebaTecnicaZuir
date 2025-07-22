using PruebaTecnica.Components;
using PruebaTecnica.Services;

var builder = WebApplication.CreateBuilder(args);

// 👇 Registro correcto del servicio que usa HttpClient
builder.Services.AddHttpClient<DocumentoService>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure pipeline
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
