using LearnASPNETCore.Data;
using LearnASPNETCore.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var sqliteConnString = builder.Configuration.GetConnectionString("sqliteConnString");
builder.Services.AddSqlite<GameStoreContext>(sqliteConnString);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGamesEndpoints();

app.MigrateDb();

app.Run();
