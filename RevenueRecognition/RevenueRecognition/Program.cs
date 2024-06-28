using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RevenueRecognition.Data;
using RevenueRecognition.Middlewares;
using RevenueRecognition.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterRepositories();
builder.Services.RegisterServices();
builder.Services.AddHttpClient();


builder.Services.AddHttpClient("ExchangeService", client =>
{
    client.BaseAddress = new Uri("https://v6.exchangerate-api.com/v6/");
});
builder.Services.AddDbContext<AppDbContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAuthentication(o =>
{
    o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["Auth:ValidIssuer"],
        ValidAudience = builder.Configuration["Auth:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Auth:SecretKey"]!))
    };
    o.Events = new JwtBearerEvents()
    {
        OnAuthenticationFailed = context =>
        {
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
                context.Response.Headers.Add("Token-expired","true");
            }
            else if (context.Exception.GetType() == typeof(SecurityTokenNotYetValidException))
            {
                context.Response.Headers.Add("Token-Not-Yet-Valid", "true");
            }
            else if (context.Exception.GetType() == typeof(SecurityTokenInvalidSignatureException))
            {
                context.Response.Headers.Add("Token-Invalid-Signature", "true");
            }
            return Task.CompletedTask;
        }
    };
}).AddJwtBearer("IgnoreTokenExpirationScheme", o =>
{
    o.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ClockSkew = TimeSpan.FromMinutes(2),
        ValidIssuer = builder.Configuration["Auth:ValidIssuer"],
        ValidAudience = builder.Configuration["Auth:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SecretKey"]))
    };
});

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();