using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SenorBarbero.Data;
using SenorBarbero.Model;
using SenorBarbero.Services;

var builder = WebApplication.CreateBuilder(args);

#region Banco de dados
var connectionString = builder.Configuration.GetConnectionString("SENORBARBERO");

builder.Services.AddDbContext<SenorBarberoDbContext>(opts =>
{
    opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services
    .AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<SenorBarberoDbContext>()
    .AddDefaultTokenProviders();
#endregion

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<UserService>();

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
