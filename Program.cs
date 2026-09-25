using SupportWebApp.Components;
using SupportWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// --- COSMOS DB REGISTRERING ---
var cosmosDbConfig = builder.Configuration.GetSection("CosmosDb");
var connectionString = cosmosDbConfig["ConnectionString"];
var databaseName = cosmosDbConfig["DatabaseName"];
var containerName = cosmosDbConfig["ContainerName"];

builder.Services.AddSingleton<ICosmosDbService>(sp => 
    new CosmosDbService(connectionString!, databaseName!, containerName!));
// ------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();