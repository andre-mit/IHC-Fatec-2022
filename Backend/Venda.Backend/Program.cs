using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Venda.Backend.Data;
using Venda.Backend.Data.Repository;
using Venda.Backend.Data.Repository.Interfaces;
using Venda.Backend.Options;
using Venda.Backend.Services;
using Venda.Backend.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Todo: implementar o banco de dados

builder.Services.AddControllers();
builder.Services.AddCors();

builder.Services.AddOptions<AuthOptions>().Bind(builder.Configuration.GetSection("AuthSettings"));

builder.Services.AddDbContext<VendaContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IColaboradorRepository, ColaboradorRepository>();
builder.Services.AddTransient<IVeiculoRepository, VeiculoRepository>();

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IVeiculoService, VeiculoService>();

var secretJwt = builder.Configuration.GetValue<string>("AuthSettings:TokenSecret");
var key = Encoding.ASCII.GetBytes(secretJwt!);

builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
