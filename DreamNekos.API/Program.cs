using DreamNekos.API.Mapper.Profiles;
using DreamNekosConnect.Lib;
using DreamNekosConnect.Lib.Providers;
using DreamNekosConnect.Lib.Services;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services.AddTransient<ProfileService>();
builder.Services.AddTransient<InterestService>();
builder.Services.AddTransient<InterestTypeService>();

builder.Services.AddAutoMapper(typeof(ProfileMapProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
