using System;
using Api.Middleware;
using Application.Cart.Query;
using Infrastructure.Job.Cart;
using Infrastructure.Job.Cart.Implements;
using Infrastructure.Job.Cart.Services;
using Infrastructure.Scheduler;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Persistence.Core;
using Persistence.Core.Services;
using Persistence.Repository.Cart;
using Persistence.Repository.Cart.Services;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            #region Scheduler

            services.AddScoped<IScopedService, ScopedService>();
            services.AddCronJob<CartCreateReportJob>(c =>
            {
                c.TimeZoneInfo = TimeZoneInfo.Local;
                //“At 03:00.” - 0 3 * * *" | every seconds 0/10 * * * * ?
                c.CronExpression = @"0 3 * * *";
            });
            services.AddCronJob<CleanCartJob>(c =>
            {
                c.TimeZoneInfo = TimeZoneInfo.Local;
                //“At 02:00.”
                c.CronExpression = @"0 2 * * *";
            });

            #endregion

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins("*");
                });
            });
            services.AddMediatR(typeof(ListCart.Handler).Assembly);
            services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(c => c.FullName);
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "CartService API"
                });
            });
            //TODO: Вынести в отдельные сервисы для планировщика, изменить SCOPE
            services.AddSingleton<IRepository, CartServiceRepository>();
            services.AddSingleton<IJobCartService, JobCartQuery>();
            services.AddSingleton<ISaveDataToSource, SaveDataToSource>();

            services.AddScoped<ICartService, CartQuery>();
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CartService API V1");
                c.DocumentTitle = "CartService API";
            });
            if (env.IsDevelopment())
            {
                // app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
