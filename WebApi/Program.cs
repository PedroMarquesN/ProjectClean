using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ProjetoClean.Application.Interfaces;
using ProjetoClean.Application.Service;
using ProjetoClean.Domain.Interfaces;
using ProjetoClean.Domain.Security.Cryptography;
using ProjetoClean.Infrastructure.Dependencies;
using ProjetoClean.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o serviço de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

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

// Adiciona serviços ao contêiner.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructureSwagger();

var app = builder.Build();

// Configura o pipeline de requisição HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStatusCodePages();
app.UseRouting();
// Adiciona o middleware de CORS
app.UseCors("AllowAllOrigins");
app.UseAuthentication();
app.UseAuthorization();



app.MapControllers();

app.Run();
