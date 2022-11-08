using BlahBlahFlat.BLL.Profiles;
using BlahBlahFlat.BLL.Services;
using BlahBlahFlat.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

RunMigrations(app.Services);

app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddTransient<IPlacementService, PlacementService>();
    services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
    var connectionString = configuration.GetConnectionString("BlahBlahFlatDatabase");
    services.AddDbContext<BlahBlahFlatContext>(x => x.UseSqlServer(connectionString));
    services.AddAutoMapper(typeof(PlacementProfile).Assembly);
}

void RunMigrations(IServiceProvider services)
{
    using var scope = services.CreateScope();
    var service = scope.ServiceProvider.GetRequiredService<BlahBlahFlatContext>();
    service.Database.Migrate();
}