using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ProjetoClean.Application.Interfaces;
using ProjetoClean.Application.Service;
using ProjetoClean.Domain.Interfaces;
using ProjetoClean.Domain.Security.Cryptography;
using ProjetoClean.Infrastructure.Dependencies;
using ProjetoClean.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddScoped<IAuthenticate, AuthenticateService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IPasswordEncripter, PasswordEncripter>();
builder.Services.AddScoped<IPageWebRepository, PageWebRepository>();
builder.Services.AddScoped<IPageWebService, PageWebService>();




builder.Services.AddDependencyInjectionJWT(builder.Configuration);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructureSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStatusCodePages();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
