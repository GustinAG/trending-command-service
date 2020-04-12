using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Trending.Command.BusinessLogic;
using Trending.Command.Contracts;
using Trending.Command.Repositories;

namespace Trending.Command.Api
{
    public class Startup
    {
        private const string SwaggerApiName = "Trending Command API";
        private const string SwaggerApiVersion = "v0";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IArticleReadScorer, Scorer>();
            services.AddTransient<IArticlesRepository, ArticlesRepository>();

            services.AddControllers();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(SwaggerApiVersion, new OpenApiInfo { Title = SwaggerApiName, Version = SwaggerApiVersion });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // ReSharper disable once UnusedMember.Global
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{SwaggerApiVersion}/swagger.json", SwaggerApiName);
            });

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(ap => ap.MapControllers());
        }
    }
}
