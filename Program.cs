using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SenorBarbero.Data;
using SenorBarbero.IServices;
using SenorBarbero.Model;
using SenorBarbero.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region Banco de dados
var connectionString = builder.Configuration["ConnectionStrings:SENORBARBERO"];

builder.Services.AddDbContext<SenorBarberoDbContext>(opts =>
{
    opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services
    .AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<SenorBarberoDbContext>()
    .AddDefaultTokenProviders();
#endregion

#region Autenticação
var symetricSecurityKey = builder.Configuration["SymmetricSecurityKey"];
if (symetricSecurityKey == null)
    throw new ApplicationException("symetricSecurityKey não informado nos secrets contidos no csproj da aplicação");

builder.Services.AddAuthentication(opts =>
{
    opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opts =>
{
    opts.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(symetricSecurityKey)),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero
    };
});
#endregion

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
