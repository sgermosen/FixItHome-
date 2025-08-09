using FixItHome.Application.Service;
using FixItHome.Infrastructure.Data;
using FixItHome.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FixItHomeApplicationContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString("MainConnection")));

 

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddScoped<UnitOfWork>();

builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<EquipmentRepository>();
builder.Services.AddScoped<GuideEquipmentRepository>();
builder.Services.AddScoped<GuideRepository>();
builder.Services.AddScoped<UserRepository>();

builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<EquipmentService>();
builder.Services.AddScoped<GuideEquipmentService>();
builder.Services.AddScoped<GuideService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
