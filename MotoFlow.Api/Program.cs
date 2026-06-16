using Microsoft.EntityFrameworkCore;
using MotoFlow.Application.Members.CreateMember;
using MotoFlow.Application.Members.Interfaces;
using MotoFlow.Infrastructure.Data;
using MotoFlow.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<ICreateMemberUseCase, CreateMemberUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
