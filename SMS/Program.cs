using LearnASPNETCore.Data;
using SMS.Data;
using SMS.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var sqliteConnString = builder.Configuration.GetConnectionString("sqliteConnString");
builder.Services.AddSqlite<SMSDbContext>(sqliteConnString);

var app = builder.Build();

app.MapGet("/", () => "API is Running!");

app.MapStudentsEndpoints();
app.MapCoursesEndpoints();
app.MapEnrollmentsEndpoints();

await app.MigrateDbAsync();

app.Run();
