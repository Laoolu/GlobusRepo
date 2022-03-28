using Application.Common.Behavior;
using Application.Common.Interface;
using Application.Handlers.Queries;
using Domain.Entities;
using Domain.Repository;
using FluentValidation;
using Infrastructure.Service;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Persistence.Context;
using Persistence.Repository;
using System.Reflection;

namespace GlobusBankOnboarding
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
            //var options = new DbContextOptionsBuilder<OnboardingContext>()
            //    .UseInMemoryDatabase(databaseName: "GlobusCustomerRecord")
            //    .Options;

            //using (var context = new OnboardingContext(options))
            //{
            //    var onboardUser = new Onboard
            //    {
            //        id = 1,
            //        phoneNumber = "08137392922",
            //        email = "sam@gmail.com",
            //        state = "lagos",
            //        lga = "ikeja"
            //    };

            //    context.Onboards.Add(onboardUser);
            //    context.SaveChanges();
            //}


            services.AddDbContextFactory<OnboardingContext>(options => options.UseInMemoryDatabase("GlobusCustomerRecord"));

            services.AddScoped<IGenericRepository, GenericRepository>();
            services.AddScoped<IRapidApiService, RapidApiService>();
            services.AddMediatR(typeof(UserQuery).Assembly);
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GlobusBankOnboarding", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("../swagger/v1/swagger.json", "GlobusBankOnboarding v1"));
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
