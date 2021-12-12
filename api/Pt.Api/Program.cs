using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using NodaTime;
using NodaTime.Serialization.JsonNet;
using ProjectTracker.Api.DB;
using ProjectTracker.Api.DB.Repositories;

JsonConvert.DefaultSettings = () => new JsonSerializerSettings
{
    ContractResolver = new CamelCasePropertyNamesContractResolver(),
    Converters = { new StringEnumConverter() },
    NullValueHandling = NullValueHandling.Ignore,
    Formatting = Formatting.Indented,
}.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);

var builder = WebApplication.CreateBuilder(args);

// Add Configuration
builder.Configuration
    .AddJsonFile("appsettings.json", reloadOnChange: true, optional: true)
    .AddJsonFile($"appsettings.{builder.Environment}.json", reloadOnChange: true, optional: true)
    .AddEnvironmentVariables("PT_API_")
    .AddCommandLine(args);

// Add AspNetCore controllers with Json
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.AllowInputFormatterExceptionMessages = true;
        options.SerializerSettings.ContractResolver =
            new CamelCasePropertyNamesContractResolver();
        options.SerializerSettings.Converters =
            new List<JsonConverter> { new StringEnumConverter() };
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        options.SerializerSettings.Formatting = Formatting.Indented;
        options.SerializerSettings.ConfigureForNodaTime(DateTimeZoneProviders
            .Tzdb);
    });

// Database
builder.Services.AddDbContext<PtDbContext>(optionsBuilder =>
    optionsBuilder.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        npgSqlOptions => npgSqlOptions.UseNodaTime()));

// 3rd party
builder.Services.AddEndpointsApiExplorer(); // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(options => options.ConfigureForNodaTime());
builder.Services.AddSingleton<IClock>(SystemClock.Instance);

// Domain Services
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

var app = builder.Build();

// Migrate DB
await using (var scope = app.Services.CreateAsyncScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PtDbContext>();
    await db.Database.MigrateAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
