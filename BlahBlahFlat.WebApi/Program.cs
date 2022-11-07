using BlahBlahFlat.BLL.Profiles;
using BlahBlahFlat.BLL.Services;
using BlahBlahFlat.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IPlacementService,PlacementService>();
var conn = builder.Configuration.GetConnectionString("BlahBlahFlatDatabase");
builder.Services.AddDbContext<BlahBlahFlatContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("BlahBlahFlatDatabase")));
builder.Services.AddAutoMapper(typeof(PlacementProfile).Assembly);
var services = builder.Services;

var app = builder.Build();

var scope = app.Services.CreateScope();
var service = scope.ServiceProvider.GetRequiredService<BlahBlahFlatContext>();
service.Database.Migrate();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
