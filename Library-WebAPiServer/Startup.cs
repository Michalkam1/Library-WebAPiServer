using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.Mappings;
using Library_WebAPiServer.Models;
using Library_WebAPiServer.Domain.Services;
using Library_WebAPiServer.Domain.Repositories;
using Library_WebAPiServer.Domain.Persistance.Repositories;
using Newtonsoft.Json;
//using Swashbuckle.AspNetCore.Swagger;
using NJsonSchema;
using NSwag.AspNetCore;


namespace Library_WebAPiServer
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options =>
                            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                            //    b => b.MigrationsAssembly("Database")));
                            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                  b => b.MigrationsAssembly("Database")));


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            /*services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Test API",
                    Description = "ASP.NET Core Web API"
                });
            });*/

            services.AddSwaggerDocument();

            services.AddScoped<IAuthorsRepository, AuthorsRepository>();
            services.AddScoped<IAuthorsServices, AuthorsServices>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ILibraryItemRepository, LibraryItemRepository>();
            services.AddScoped<ILibraryItemService, LibraryItemService>();


            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUi3();
            /*app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });*/

        }
    }
}
