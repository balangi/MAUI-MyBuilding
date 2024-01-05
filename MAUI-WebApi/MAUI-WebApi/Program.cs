using Farabeh.MyBuilding.Api.Core.Domain.Buildings.Interfaces;
using Farabeh.MyBuilding.Api.Core.Domain.Roles.Dtos;
using Farabeh.MyBuilding.Api.Core.Domain.Roles.Interfaces;
using Farabeh.MyBuilding.Api.Core.Domain.Settings.Interfaces;
using Farabeh.MyBuilding.Api.Core.Domain.UserClaims.Interfaces;
using Farabeh.MyBuilding.Api.Core.Domain.UserRoles.Interfaces;
using Farabeh.MyBuilding.Api.Core.Domain.Users.Dtos;
using Farabeh.MyBuilding.Api.Core.Domain.Users.Interfaces;
using Farabeh.MyBuilding.Api.Infra.Data.Sql.Common;
using Farabeh.MyBuilding.Api.Infra.Data.Sql.Pages;
using Farabeh.MyBuilding.Api.Infra.Data.Sql.Roles;
using Farabeh.MyBuilding.Api.Infra.Data.Sql.Settings;
using Farabeh.MyBuilding.Api.Infra.Data.Sql.UserClaims;
using Farabeh.MyBuilding.Api.Infra.Data.Sql.UserRoles;
using Farabeh.MyBuilding.Api.Infra.Data.Sql.Users;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<SqlDbContext>
    (c => c.UseSqlServer(connectionString));

builder.Services.AddScoped<IBuildingRepository, BuildingRepository>();

builder.Services.AddIdentity<UserDto, RoleDto>().AddEntityFrameworkStores<SqlDbContext>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ISettingsRepository, SettingsRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserClaimRepository, UserClaimRepository>();
builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();

var app = builder.Build();

var loggerFactory = (ILoggerFactory)app.Services.GetService(typeof(ILoggerFactory))!;
loggerFactory.AddLog4Net();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
