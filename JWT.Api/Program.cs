using JWT.Api.Middlewares;
using JWT.Application.Interfaces.Order;
using JWT.Application.Interfaces.Security;
using JWT.Application.Mappers.OrderMapper;
using JWT.Application.Queries.Orders;
using JWT.Domain.Context;
using JWT.Infrastructure.DomainServices.OrderDomainService;
using JWT.Infrastructure.DomainServices.SecurityDomainService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Read Jwt Config
var jwt = builder.Configuration.GetSection("Jwt");
var issuer = jwt["Issuer"];
var audience = jwt["Audience"];
var keystring = jwt["Key"];
var key = Encoding.UTF8.GetBytes(keystring);
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(option =>
{
    option.RequireHttpsMetadata = !builder.Environment.IsDevelopment();
    option.SaveToken = true;
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = issuer,

        ValidateAudience = true,
        ValidAudience = audience,

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),

        ValidateLifetime = true,
        ClockSkew = TimeSpan.FromSeconds(60)
    };
});
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddControllers();
// Dependency Injection
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IOrderService, OrderService>();
var applicationAssembly = typeof(GetOrdersQuery).Assembly;

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssemblies(
        typeof(Program).Assembly,
        applicationAssembly
    );
});
builder.Services.AddAutoMapper(typeof(OrderMappingProfile));
var app = builder.Build();
// Middle wares
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<TokenAuthenticationMiddleware>();
app.Run();
