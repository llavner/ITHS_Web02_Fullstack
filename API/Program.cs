using Core.Interfaces;
using Data.DatabaseContext;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "CRUD-API",
        Description = "An ASP.NET Core Web API for managing products, users, categories and orders in E-Commerce",
        TermsOfService = new Uri("https://github.com/llavner/ITHS_Web02_Fullstack/blob/master/API-spec.md"),
        Contact = new OpenApiContact
        {
            Name = "Marcus Renvall",
            Url = new Uri("https://github.com/llavner")
        }
    });
});

// ConnectionString DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLconnection")));

// Register Repository Service
builder.Services.AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<ICatogoryRepository, CategoryRepository>()
                .AddScoped<IOrderRepository, OrderRepository>();

// API Controllers
builder.Services.AddControllers();

// HttpClient
builder.Services.AddHttpClient();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

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

app.UseCors("AllowAll");

app.Run();
