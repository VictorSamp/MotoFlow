using Microsoft.EntityFrameworkCore;
using MotoFlow.Application.Activities.CreateActivity;
using MotoFlow.Application.Activities.DeleteActivity;
using MotoFlow.Application.Activities.GetActivityById;
using MotoFlow.Application.Activities.GetAllActivities;
using MotoFlow.Application.Activities.Interfaces;
using MotoFlow.Application.Activities.UpdateActivity;
using MotoFlow.Application.Commom.Interfaces;
using MotoFlow.Application.Members.ActivateMember;
using MotoFlow.Application.Members.CreateMember;
using MotoFlow.Application.Members.DeleteMember;
using MotoFlow.Application.Members.GetAllMembers;
using MotoFlow.Application.Members.GetMemberById;
using MotoFlow.Application.Members.GetMemberDetails;
using MotoFlow.Application.Members.Interfaces;
using MotoFlow.Application.Members.UpdateMember;
using MotoFlow.Application.Members.UpdateMemberPatchLevel;
using MotoFlow.Application.MembershipFees.CreateMembershipFee;
using MotoFlow.Application.MembershipFees.DeleteMembershipFee;
using MotoFlow.Application.MembershipFees.GetMembershipFeeById;
using MotoFlow.Application.MembershipFees.Interfaces;
using MotoFlow.Application.MembershipFees.PayMembershipFee;
using MotoFlow.Infrastructure.Data;
using MotoFlow.Infrastructure.Persistence;
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

builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IGetAllMembersUseCase, GetAllMembersUseCase>();
builder.Services.AddScoped<IGetMemberByIdUseCase, GetMemberByIdUseCase>();
builder.Services.AddScoped<ICreateMemberUseCase, CreateMemberUseCase>();
builder.Services.AddScoped<IUpdateMemberUseCase, UpdateMemberUseCase>();
builder.Services.AddScoped<IDeleteMemberUseCase, DeleteMemberUseCase>();
builder.Services.AddScoped<IActivateMemberUseCase, ActivateMemberUseCase>();
builder.Services.AddScoped<IGetMemberDetailsUseCase, GetMemberDetailsUseCase>();
builder.Services.AddScoped<IUpdateMemberPatchLevelUseCase, UpdateMemberPatchLevelUseCase>();

builder.Services.AddScoped<IMembershipFeeRepository, MembershipFeeRepository>();
builder.Services.AddScoped<IGetMembershipFeeByIdUseCase, GetMembershipFeeByIdUseCase>();
builder.Services.AddScoped<ICreateMembershipFeeUseCase, CreateMembershipFeeUseCase>();
builder.Services.AddScoped<IDeleteMembershipFeeUseCase, DeleteMembershipFeeUseCase>();
builder.Services.AddScoped<IPayMembershipFeeUseCase, PayMembershipFeeUseCase>();

builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<ICreateActivityUseCase, CreateActivityUseCase>();
builder.Services.AddScoped<IGetAllActivitiesUseCase, GetAllActivitiesUseCase>();
builder.Services.AddScoped<IGetActivityByIdUseCase, GetActivityByIdUseCase>();
builder.Services.AddScoped<IUpdateActivityUseCase, UpdateActivityUseCase>();
builder.Services.AddScoped<IDeleteActivityUseCase, DeleteActivityUseCase>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


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
