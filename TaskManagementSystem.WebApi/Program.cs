using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using TaskManagementSystem.Repositories;
using TaskManagementSystem.Repositories.Implemenatation;
using TaskManagementSystem.WebApi.Database;
using TaskManagementSystem.WebApi.Database.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
 
//Dependency Injections  
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<TaskRepository>();
builder.Services.AddScoped<DeveloperRepository>();
builder.Services.AddScoped<TaskStatusRepository>();
// Added DbContext
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

// new Code Using Website https://code-maze.com/upload-files-dot-net-core-angular/
builder.Services.Configure<FormOptions>(x =>
{
    x.ValueLengthLimit = int.MaxValue;
    x.MultipartBoundaryLengthLimit = int.MaxValue;
    x.MemoryBufferThreshold = int.MaxValue;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x =>
{
    x.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin();

});
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot")),
    RequestPath = new PathString("/wwwroot")
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
