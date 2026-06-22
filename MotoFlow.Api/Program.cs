using Microsoft.EntityFrameworkCore;
using MotoFlow.Application.Members.ActivateMember;
using MotoFlow.Application.Members.CreateMember;
using MotoFlow.Application.Members.DeleteMember;
using MotoFlow.Application.Members.GetAllMembers;
using MotoFlow.Application.Members.GetMemberById;
using MotoFlow.Application.Members.Interfaces;
using MotoFlow.Application.Members.UpdateMember;
using MotoFlow.Application.MembershipFees.CreateMembershipFee;
using MotoFlow.Application.MembershipFees.DeleteMembershipFee;
using MotoFlow.Application.MembershipFees.GetMembershipFeeById;
using MotoFlow.Application.MembershipFees.Interfaces;
using MotoFlow.Infrastructure.Data;
using MotoFlow.Infrastructure.Persistence.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter()
        );
    });
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Member services
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IGetAllMembersUseCase, GetAllMembersUseCase>();
builder.Services.AddScoped<IGetMemberByIdUseCase, GetMemberByIdUseCase>();
builder.Services.AddScoped<ICreateMemberUseCase, CreateMemberUseCase>();
builder.Services.AddScoped<IUpdateMemberUseCase, UpdateMemberUseCase>();
builder.Services.AddScoped<IDeleteMemberUseCase, DeleteMemberUseCase>();
builder.Services.AddScoped<IActivateMemberUseCase, ActivateMemberUseCase>();

// Membership fee services
builder.Services.AddScoped<IMembershipFeeRepository, MembershipFeeRepository>();
builder.Services.AddScoped<IGetMembershipFeeByIdUseCase, GetMembershipFeeByIdUseCase>();
builder.Services.AddScoped<ICreateMembershipFeeUseCase, CreateMembershipFeeUseCase>();
builder.Services.AddScoped<IDeleteMembershipFeeUseCase, DeleteMembershipFeeUseCase>();


builder.WebHost.UseUrls("http://0.0.0.0:8080");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
