using System.Text.Json;

var appSettingsPath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");

if (!File.Exists(appSettingsPath))
{
    appSettingsPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
}

if (!File.Exists(appSettingsPath))
{
    Console.WriteLine("No se encontró el archivo appsettings.json");
    return;
}

var json = File.ReadAllText(appSettingsPath);
var config = JsonSerializer.Deserialize<Configuration>(json, new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true
});

if (config?.ConnectionStrings?.DefaultConnection is null)
{
    Console.WriteLine("No existe la cadena de conexión simulada.");
    return;
}

Console.WriteLine("Simulación de cadena de conexión");
Console.WriteLine($"Ambiente: {config.AppSettings?.Environment ?? "Desconocido"}");
Console.WriteLine($"Cadena de conexión: {config.ConnectionStrings.DefaultConnection}");

public class Configuration
{
    public ConnectionStringsSection? ConnectionStrings { get; set; }
    public AppSettingsSection? AppSettings { get; set; }
}

public class ConnectionStringsSection
{
    public string? DefaultConnection { get; set; }
}

public class AppSettingsSection
{
    public string? Environment { get; set; }
    public bool SimulationEnabled { get; set; }
}

string stripeApiKey = "sk_test_51H1v5qJZ1Z1Z1Z1Z1Z1Z1Z1Z1Z1Z1Z1Z1Z1Z1Z1Z1Z1Z1Z1Z1Z1Z1Z1Z";