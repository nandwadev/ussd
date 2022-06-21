using System.Net.Mime;
using System.Reflection;
using MediatR;
using StackExchange.Redis;
using USSD.Contracts;
using USSD.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IConnectionMultiplexer>(opt=> ConnectionMultiplexer.Connect(
    builder.Configuration.GetConnectionString("RedisConnection")
    ));
builder.Services.AddScoped<IUssdRepository, UssdRepository>(); 
builder.Services.AddControllers(options =>
{
    options.RespectBrowserAcceptHeader = true;
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(USSD.Assembly.AssemblyReference).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
