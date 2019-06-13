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

            //AutoMapperModelToResource autoMapperModelToResource = new AutoMapperModelToResource();
            //AutoMapperResourceToModel autoMapperResourceToModel = new AutoMapperResourceToModel();
            services.AddAutoMapper();

            //var config = new MapperConfiguration(cfg => { new AutoMapperModelToResource();
            //                                              new AutoMapperResourceToModel();
            //                                            });

            //IMapper mapper = new Mapper(config);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<IAuthorsRepository, AuthorsRepository>();
            services.AddScoped<IAuthorsServices, AuthorsServices>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
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
        }
    }
}
