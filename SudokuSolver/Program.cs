using SudokuSolver.Data;
using SudokuSolver.Options;
using SudokuSolver.SqlUtils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SudokuSolver.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<DbConfigOption>(builder.Configuration.GetSection(DbConfigOption.Section));
builder.Services.AddTransient<ISqlUtil, SqlUtil>();
//builder.Services.AddTransient<SudokuSolverContext>();
builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();
builder.Services.AddDbContext<SudokuSolverContext>();
builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<SudokuSolverContext>()
    .AddApiEndpoints(); 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("https://localhost:44351", "http://localhost:3000")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
