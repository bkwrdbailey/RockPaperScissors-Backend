using RockPaperScissorsBackend.Services;
using RockPaperScissorsBackend.DatabaseCalls;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<IUserDatabaseCalls, UserDatabaseCalls>();
builder.Services.AddScoped<ISessionDatabaseCalls, SessionDatabaseCalls>();

builder.Services.AddDbContext<RockPaperScissorsDBContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("RockPaperScissorsDB")));

var app = builder.Build();

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