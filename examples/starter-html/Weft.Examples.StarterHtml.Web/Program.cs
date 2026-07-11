using Weft.Examples.StarterHtml.Feature;
using Weft.Server;

var builder = WebApplication.CreateBuilder(args);

// The host explicitly chooses the feature modules it trusts.
builder.Services.AddWeft(TasksFeature.Manifest);

var app = builder.Build();

app.UseAntiforgery();
app.MapWeft();
app.MapGet("/", static () => Results.Redirect("/tasks"));

app.Run();

public partial class Program;
