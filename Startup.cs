using Context;
using Idopontfoglalo_Rendszer.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Idopontfoglalo_Rendszer;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<EmailSender>();
        services.Configure<SmtpSettings>(Configuration.GetSection("SMTP"));

        services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

        // SQLite adatbázis
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

        services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin", builder =>
                builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
        });

        services.AddSwaggerGen(c =>
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Idopontfoglalo_Rendszer API", Version = "v1" }));

        services.AddSpaStaticFiles(configuration =>
        {
            configuration.RootPath = "ClientApp/dist";
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Idopontfoglalo_Rendszer API v1");
                c.RoutePrefix = "swagger";
            });
        }
        else
        {
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Append("Content-Security-Policy",
                    "default-src 'self'; " +
                    "connect-src 'self' https://identitytoolkit.googleapis.com https://securetoken.googleapis.com https://www.googleapis.com https://*.firebaseapp.com; " +
                    "script-src 'self' https://apis.google.com https://www.gstatic.com; " +
                    "frame-src https://*.firebaseapp.com https://accounts.google.com; " +
                    "img-src 'self' data: https://*.googleusercontent.com; " +
                    "style-src 'self' 'unsafe-inline';");
                await next();
            });
            app.UseExceptionHandler("/Error");
        }

        app.UseStaticFiles();
        app.UseSpaStaticFiles();

        app.UseRouting();
        app.UseCors("AllowSpecificOrigin");

        app.UseEndpoints(endpoints => endpoints.MapControllers());

        app.UseSpa(spa =>
        {
            spa.Options.SourcePath = "ClientApp";
            if (env.IsDevelopment()) spa.UseAngularCliServer("start");
        });
    }
}