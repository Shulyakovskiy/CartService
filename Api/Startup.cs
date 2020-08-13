using Api.Middleware;
using Application.Cart.Query;
using Infrastructure.Job.Cart;
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
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

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

            services.AddSingleton<IJobFactory, JobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            services.AddHostedService<QuartzHostedService>();

            services.AddSingleton<CleanCartJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(CleanCartJob),
                cronExpression: "0 2 * * *")); //“At 02:00.”

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
            services.AddScoped<IRepository, CartServiceRepository>();
            services.AddScoped<ICartService, CartQuery>();
            services.AddScoped<IJobCartService, JobCartQuery>();
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
