using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.API.Filters;
using CleanArchitecture.API.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
//using NSwag;
//using NSwag.Generation.Processors.Security;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddAPIServices(this IServiceCollection services)
    {
        //services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddSingleton<ICurrentUserService, CurrentUserService>();

        //services.AddHttpContextAccessor();

        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

        //services.AddControllersWithViews(options =>
        //    options.Filters.Add<ApiExceptionFilterAttribute>())
        //        .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

        //services.AddRazorPages();

        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        //services.AddOpenApiDocument(configure =>
        //{
        //    configure.Title = "CleanArchitecture API";
        //    configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
        //    {
        //        Type = OpenApiSecuritySchemeType.ApiKey,
        //        Name = "Authorization",
        //        In = OpenApiSecurityApiKeyLocation.Header,
        //        Description = "Type into the textbox: Bearer {your JWT token}."
        //    });

        //    configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
        //});

        services.AddControllers();

        services.AddEndpointsApiExplorer();
        //services.AddSwaggerGen(c =>
        //{
        //    c.SwaggerDoc("v1", 
        //        new OpenApi.Models.OpenApiInfo {
        //            Title = "CleanArchitecture",
        //            Version = "v1"
        //        });
        //    c.AddSecurityDefinition("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
        //    {
        //        Type = SecuritySchemeType.ApiKey,
        //        Name = "Authorization",
        //        In = ParameterLocation.Header,
        //        Description = "Type into the textbox: Bearer {your JWT token}."
        //   });
        //});

        //services.AddSwaggerGen(c =>
        //{
        //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BasicAuth", Version = "v1" });
        //    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
        //    {
        //        Name = "Authorization",
        //        Type = SecuritySchemeType.Http,
        //        Scheme = "basic",
        //        In = ParameterLocation.Header,
        //        Description = "Basic Authorization header using the Bearer scheme."
        //    });
        //    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        //        {
        //            {
        //                  new OpenApiSecurityScheme
        //                    {
        //                        Reference = new OpenApiReference
        //                        {
        //                            Type = ReferenceType.SecurityScheme,
        //                            Id = "basic"
        //                        }
        //                    },
        //                    new string[] {}
        //            }
        //        });
        //});

        services.AddSwaggerGen(setup =>
        {
            // Include 'SecurityScheme' to use JWT Authentication
            var jwtSecurityScheme = new OpenApiSecurityScheme
            {
                BearerFormat = "JWT",
                Name = "JWT Authentication",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };

            setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

            setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });

        });

        //if (app.Environment.IsDevelopment())
        //{
        //    app.UseSwagger();
        //    app.UseSwaggerUI();
        //}

        //app.UseSwaggerUI(options =>
        //{
        //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        //    options.RoutePrefix = string.Empty;
        //});


        return services;
    }
}
