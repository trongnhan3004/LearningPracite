using Microsoft.EntityFrameworkCore;
using BaitapLeaning.Model;
using BaitapLeaning;
using Microsoft.AspNetCore.Identity;
using BaitapLeaning.Interface;
using BaitapLeaning.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));
builder.Services.AddScoped<IClass, ClassRepository>();
builder.Services.AddScoped<IContentTest, ContentTestRepository>();
builder.Services.AddScoped<IDocument, DocumentRepository>();
builder.Services.AddScoped<IRole, RoleRepository>();
builder.Services.AddScoped<ISemester, SemesterRepository>();
builder.Services.AddScoped<ISchedule, ScheduleRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.MapControllers();

app.Run();