
using e07.application.dto;
using e07.application.dto.validator;
using e07.application.service;
using e07.domain.repository;
using e07.domain.unitofwork;
using e07.infrastructure;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace e07;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<DbContext, DbDataContext>();

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        builder.Services.AddScoped<IValidator<DeveloperModificationDTO>, DeveloperModificationDTOValidator>();
        builder.Services.AddScoped<IDeveloperService, DeveloperService>();

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        var app = builder.Build();

        app.UseHttpsRedirection();

        app.MapControllers();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.Run();
    }
}