using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sat.Recruitment.Application.Factories;
using Sat.Recruitment.Application.Processors;
using Sat.Recruitment.Application.Services;
using Sat.Recruitment.Domain;
using Sat.Recruitment.Domain.Contracts;
using Sat.Recruitment.Infrastructure.Contracts;
using Sat.Recruitment.Infrastructure.Implementations;
using Sat.Recruitment.Infrastructure.Settings;
using Sat.Recruitment.DataAccess.Repositories;
using Sat.Recruitment.Domain.ValueObjects;
using Sat.Recruitment.Infrastructure.Mappers;

namespace Sat.Recruitment.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuration
            services.Configure<FileSystemDataLoaderSettings>(Configuration.GetSection(nameof(FileSystemDataLoaderSettings)));

            //Services
            services.AddTransient<IUserApplicationService, UserApplicationService>();
            services.AddTransient<IRewardService, RewardService>();

            services.AddTransient<IRewardProcessorFactory, RewardProcessorFactory>();
            
            // Processors
            services.AddTransient<PremiumUserRewardProcessor>();
            services.AddTransient<NormalUserRewardProcessor>();
            services.AddTransient<SuperUserRewardProcessor>();

            // Repositories
            services.AddTransient<IUserRepository, UserRepository>();

            // Infrastructure
            services.AddTransient<IDataLoader, FileSystemDataLoader>();
            services.AddTransient<IPathBuilder, PathBuilder>();
            services.AddTransient<IDataSerializer<User>, SplitSerializer<User>>();
            services.AddTransient<IDataSerializerMapper<User>, UserSplitSerializerMapper>();

            services.AddControllers();
            services.AddSwaggerGen();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting(); 

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
