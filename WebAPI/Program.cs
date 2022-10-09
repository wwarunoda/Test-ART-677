using Application.Services;
using Application.Services.Abstractions;
using Domain.Repositories.Abstractions;
using ExceptionHandling.Middlewares;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.HttpLogging;
using NLog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ApplicationDbContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IResidenceService, ResidenceService>();
builder.Services.AddScoped<IResidenceRepository, ResidenceRepository>();
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();

//Enable cores
var devCorsPolicy = "devCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(devCorsPolicy, builder => {
        //builder.WithOrigins("http://localhost:3001").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        //builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
        //builder.SetIsOriginAllowed(origin => true);
    });
});

//Configure logger service
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

//Get logging instance
var logger = builder.Services.BuildServiceProvider().GetService<ILoggerManager>();

builder.Services.AddHttpLogging(logging =>
{
    
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.MediaTypeOptions.AddText("application/javascript");

});

var app = builder.Build();

app.UseHttpLogging();
app.UseMiddleware<ExceptionMiddlewareExtensions>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Use(async (context, next) =>
{
    // Do work that can write to the Response.
    logger.LogInfo(context.Request.Path, context.Request.Query["state"].ToString());
    await next.Invoke();
    // Do logging or other work that doesn't write to the Response.
});

app.Run();
